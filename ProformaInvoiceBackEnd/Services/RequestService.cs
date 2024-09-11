using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;
using static ProformaInvoiceBackEnd.DTOs.CreateRequestDTO;

namespace ProformaInvoiceBackEnd.Services
{
    public class RequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RequestService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Request
        public async Task<request> CreateRequest(CreateRequestDTO dto)
        {
            var request = _mapper.Map<request>(dto);
            request.status = RequestStatus.PendingInFinance;
            request.created_at = DateTime.Now;
            request.InvoiceAddress = "TE Connectivity Morocco SARL Zone Franche" +
                                     "Logistique Tangier Med Lot 130 Bureau # 3," +
                                     "PO Box 119 94152 Ksar Al Majaz Morocco\n " +
                                      "VIA Reg No: MA40432316\n" +
                                      "ICE : 000060478000089";
            request.ExporterAddress =
                                      "TE Connectivity Morocco SARL Zone Franche" +
                                      " Logistique Tangier Med Lot 130 Bureau # 3," +
                                      " PO Box 119 94152 Ksar Al Majaz Morocco\n " +
                                      "VIA Reg No: MA40432316\n" +
                                      "ICE : 000060478000089";

            _context.request.Add(request);
            await _context.SaveChangesAsync();

            //await CreateItemRequests(dto.Items, request.RequestNumber);
            await CreateApproverRequests(request);

            return request;
        }

        /*private async Task CreateItemRequests(ICollection<CreateItemDTO> items, int requestNumber)
        {
            foreach (var itemDto in items)
            {
                var item = _mapper.Map<Items>(itemDto);
                item.RequestNumber = requestNumber;
                _context.Item.Add(item);
            }

            await _context.SaveChangesAsync();
        }*/
        private async Task CreateApproverRequests(request request)
        {
            var approvers = await _context.Approverscenario
                .Where(a => a.scenarioId == request.scenarioId)
                .OrderBy(a => a.classe)
                .ToListAsync();

            foreach (var approver in approvers)
            {
                var approverRequest = new ApproverRequest
                {
                    RequestId = request.RequestNumber,
                    role = approver.role,
                    classe = approver.classe,
                    Date = DateTime.Now
                };

                _context.ApproverRequest.Add(approverRequest);
            }

            await _context.SaveChangesAsync();
        }



        // Get all requests
        public async Task<List<request>> GetAllRequests()
        {
            return await _context.request
                .Include(r => r.Scenario)
                .Include(r => r.User)
                .Include(r => r.shippoint)
                .ToListAsync();
        }

        // Get request by ID
        public async Task<request> GetRequestById(int id)
        {
            var request = await _context.request
                                .Include(r => r.Item)
                                .FirstOrDefaultAsync(r => r.RequestNumber == id);
            return request;
            
        }

        // Delete request
        public async Task<bool> DeleteRequest(int id)
        {
            var entity = await _context.request.Include(r => r.ApproverRequest).FirstOrDefaultAsync(r => r.RequestNumber == id);
            if (entity == null)
            {
                return false;
            }

            // Delete related ApproverRequests
            if (entity.ApproverRequest != null && entity.ApproverRequest.Any())
            {
                _context.ApproverRequest.RemoveRange(entity.ApproverRequest);
            }

            _context.request.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        // Update Request by Finance
        // Update Request by Finance
        public async Task<bool> UpdateRequestByFinance(int requestNumber, UpdateFinanceRequestDTO dto)
        {
            var request = await _context.request
                                        .Include(r => r.Item) // Include items in the request
                                        .FirstOrDefaultAsync(r => r.RequestNumber == requestNumber);
            if (request == null)
            {
                Console.WriteLine("Request not found"); // Log if the request is not found
                return false;
            }

            // Update request properties
            request.incoterm = dto.incoterm;
            request.DHLACCOUNT = dto.dhlAccount;
            request.status = RequestStatus.PendingInTradCompliance;
            request.userId = dto.userId; 
            

            // Update UNITVALUEFINANCE for each item in the request
            foreach (var itemDto in dto.Items)
            {
                var item = request.Item.FirstOrDefault(i => i.id_items == itemDto.id_items);
                if (item != null)
                {
                    item.UNITVALUEFINANCE = itemDto.UNITVALUEFINANCE;
                    _context.Item.Update(item);
                }
            }

            // Update ApproverRequest
            var approverRequest = await _context.ApproverRequest
                .FirstOrDefaultAsync(ar => ar.RequestId == requestNumber && ar.role == "finance");
            if (approverRequest != null)
            {
                approverRequest.userId = dto.userId;
                approverRequest.status = RequestStatus.PendingInTradCompliance;
                approverRequest.status_datetime = DateTime.Now;
                _context.ApproverRequest.Update(approverRequest);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateRequestByTradCompliance(int requestNumber, UpdateTradComplianceRequestDTO dto)
        {
            var request = await _context.request.FindAsync(requestNumber);
            if (request == null)
            {
                return false;
            }

            request.HTSCODE = dto.HTSCODE;
            request.COO = dto.COO;
            request.status = RequestStatus.InShipping;
            request.userId = dto.userId; // assuming the DTO has userId
            _context.request.Update(request);

            // Update ApproverRequest
            var approverRequest = await _context.ApproverRequest
                .FirstOrDefaultAsync(ar => ar.RequestId == requestNumber && ar.role == "tradcompliance");
            if (approverRequest != null)
            {
                approverRequest.userId = dto.userId;
                approverRequest.status = RequestStatus.InShipping;
                approverRequest.status_datetime = DateTime.Now;
                _context.ApproverRequest.Update(approverRequest);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRequestByWarehouse(int requestNumber, UpdateWarehouseRequestDTO dto)
        {
            var request = await _context.request.FindAsync(requestNumber);
            if (request == null)
            {
                return false;
            }

            request.TRACKINGNUMBER = dto.TRACKINGNUMBER;
            request.NUMBEROFBOXES = dto.NUMBEROFBOXES;
            request.WEIGHT = dto.WEIGHT;
            request.MODEOFTRANSPORT = dto.MODEOFTRANSPORT;
            request.SHIPPEDVIA = dto.SHIPPEDVIA;
            request.status = RequestStatus.Done;
            request.userId = dto.userId; // assuming the DTO has userId
            _context.request.Update(request);

            // Update ApproverRequest
            var approverRequest = await _context.ApproverRequest
                .FirstOrDefaultAsync(ar => ar.RequestId == requestNumber && ar.role == "warehouse");
            if (approverRequest != null)
            {
                approverRequest.userId = dto.userId;
                approverRequest.status = RequestStatus.Done;
                approverRequest.status_datetime = DateTime.Now;
                _context.ApproverRequest.Update(approverRequest);
            }
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RejectRequest(int requestNumber, RejectRequestDTO dto)
        {
            var request = await _context.request.FindAsync(requestNumber);
            if (request == null)
            {
                return false;
            }

            request.status = RequestStatus.Rejected;
            request.userId = dto.userId;
            _context.request.Update(request);

            var approverRequest = await _context.ApproverRequest
                .FirstOrDefaultAsync(ar => ar.RequestId == requestNumber && ar.role == "finance");
            if (approverRequest != null)
            {
                approverRequest.userId = dto.userId;
                approverRequest.status = RequestStatus.Rejected;
                approverRequest.comment = dto.comment;
                approverRequest.status_datetime = DateTime.Now;
                _context.ApproverRequest.Update(approverRequest);
            }
            await _context.SaveChangesAsync();
            return true;
        }
      


    }
}

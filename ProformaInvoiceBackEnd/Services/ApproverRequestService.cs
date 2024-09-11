using AutoMapper;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.Services
{
    public class ApproverRequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApproverRequestService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //create
        public async Task<CreateApproverRequestDTO> CreateApproverRequest(CreateApproverRequestDTO dto)
        {
            var entity = _mapper.Map<ApproverRequest>(dto);
            _context.ApproverRequest.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CreateApproverRequestDTO>(entity);
        }
    }
}

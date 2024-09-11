using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.Services
{
    public class RequestItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;

        public RequestItemService(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration; // Initialisez IConfiguration
            _jwtSecret = _configuration["JwtConfig:Key"]; // Récupérez la clé secrète JWT à partir de la configuration
            _mapper = mapper;
        }

        //CreateRequestItem
        public async Task<request_itemDTO> CreateRequestItem(request_itemDTO dto)
        {
            var entity = _mapper.Map<request_item>(dto);
            _context.requestsItem.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<request_itemDTO>(entity);
        }


        //GetAllRequestItems
        public async Task<List<request_itemDTO>> GetAllRequestItems()
        {
            var RequestItems = await _context.requestsItem.ToListAsync();
            return _mapper.Map<List<request_itemDTO>>(RequestItems);
        }

        //GetRequestItemById
        public async Task<request_itemDTO> GetRequestItemById(int id)
        {
            var RequestItem = await _context.requestsItem.FindAsync(id);
            return _mapper.Map<request_itemDTO>(RequestItem);
        }

        //UpdateRequestItem
        public async Task<request_itemDTO> UpdateRequestItem(int id, request_itemDTO dto)
        {
            var entity = _mapper.Map<request_item>(dto);
            entity.Id_request_item = id;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<request_itemDTO>(entity);
        }

        //DeleteRequestItem
        public async Task<bool> DeleteRequestItem(int id)
        {
            var entity = await _context.requestsItem.FindAsync(id);
            if (entity == null)
                return false;

            _context.requestsItem.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

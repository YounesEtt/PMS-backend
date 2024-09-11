using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.Services
{
    public class ShipPointService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;

        public ShipPointService(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration; // Initialisez IConfiguration
            _jwtSecret = _configuration["JwtConfig:Key"]; // Récupérez la clé secrète JWT à partir de la configuration
            _mapper = mapper;
        }

        // CreateShipPoint
        public async Task<shippoint> CreateShipPoint(shipPointDTO ship)
        {
            var ship1 = _mapper.Map<shippoint>(ship);
            _context.shippoint.Add(ship1);
            await _context.SaveChangesAsync();
            return _mapper.Map<shippoint>(ship);
        }

        // GetAllShipPoints
        public async Task<List<shippoint>> GetAllshipPoints()
        {
            var shippoints = await _context.shippoint.ToListAsync();
            return shippoints;
        }

        // GetShipPointById
        public async Task<shipPointDTO> GetshipPointById(int id)
        {
            var shippoint = await _context.shippoint.FindAsync(id);
            if (shippoint == null)
            {
                return null;
            }
            return _mapper.Map<shipPointDTO>(shippoint);
        }

        // UpdateShipPoint
        public async Task<shipPointDTO> UpdateshipPoint(int id, shipPointDTO dto)
        {
            var shippoint = await _context.shippoint.FindAsync(id);
            if (shippoint == null)
            {
                return null;
            }

            _mapper.Map(dto, shippoint);
            await _context.SaveChangesAsync();
            return _mapper.Map<shipPointDTO>(shippoint);
        }

        // DeleteShipPoint
        public async Task<bool> DeleteshipPoint(int id)
        {
            var entity = await _context.shippoint.FindAsync(id);
            if (entity == null)
                return false;

            _context.shippoint.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

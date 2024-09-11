using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.Services
{
    public class DepartementService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;
        private Departement departement;

        public DepartementService(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration; // Initialisez IConfiguration
            _jwtSecret = _configuration["JwtConfig:Key"]; // Récupérez la clé secrète JWT à partir de la configuration
            _mapper = mapper;
        }
        // CreateDepartement
        public async Task<Departement> CreateDepartement(departementDTO dto)
        {
            var entity = _mapper.Map<Departement>(dto);
            _context.departement.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // GetAllDepartements
        public async Task<List<Departement>> GetAllDepartements()
        {
            return await _context.departement.ToListAsync();
        }

        // GetDepartementById
        public async Task<Departement> GetDepartementsById(int id)
        {
            var departement = await _context.departement.FirstOrDefaultAsync(r => r.Id_departement == id);
            return departement;
        }
        // UpdateDepartement
        public async Task<Departement> UpdateDepartement(int id, departementDTO dto)
        {
            var entity = await _context.departement.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(dto, entity); // Map only the properties that need to be updated

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        // DeleteDepartement
        public async Task<bool> DeleteDepartement(int id)
        {
            var departement = await _context.departement.FindAsync(id);
            if (departement == null)
                return false;

            _context.departement.Remove(departement);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<string>> SearchManagers(string query)
        {
            // Assuming that 'Departement' has a property 'Manager' that stores manager names
            return await _context.departement
                .Where(d => d.manager.Contains(query))
                .Select(d => d.manager)
                .Distinct()
                .ToListAsync();
        }
    }
}

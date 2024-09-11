using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProformaInvoiceBackEnd.Services
{
    public class plantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;

        public plantService(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration; // Initialisez IConfiguration
            _jwtSecret = _configuration["JwtConfig:Key"]; // Récupérez la clé secrète JWT à partir de la configuration
            _mapper = mapper;
        }

        //CreatePlant
        public async Task<plantDTO> CreatePlant(plantDTO dto)
        {
            var entity = _mapper.Map<plant>(dto);
            _context.plant.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<plantDTO>(entity);
        }


        //GetAllPlants
        public async Task<List<plantDTO>> GetAllPlants()
        {
            var plants = await _context.plant.ToListAsync();
            return _mapper.Map<List<plantDTO>>(plants);
        }

        //GetPlantById
        public async Task<plantDTO> GetPlantById(int id)
        {
            var plant = await _context.plant.FindAsync(id);
            return _mapper.Map<plantDTO>(plant);
        }

        //UpdatePlant
        public async Task<plantDTO> UpdatePlant(int id, plantDTO dto)
        {
            var entity = _mapper.Map<plant>(dto);
            entity.Id_plant = id;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<plantDTO>(entity);
        }

        //DeletePlant
        public async Task<bool> DeletePlant(int id)
        {// Recherche et suppression de toutes les associations dans userplant où Id_plant est utilisé.
            var associatedUserPlants = _context.userplant.Where(up => up.Id_plant == id).ToList();
            if (associatedUserPlants.Any())
            {
                _context.userplant.RemoveRange(associatedUserPlants);
                await _context.SaveChangesAsync();
            }

            // Recherche de la plante spécifiée
            var entity = await _context.plant.FindAsync(id);
            if (entity == null)
                return false;

            // Suppression de la plante
            _context.plant.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<string>> SearchManagerPlants(string query)
        {
            // Assuming that 'Departement' has a property 'Manager' that stores manager names
            return await _context.plant
                .Where(d => d.Manager_plant.Contains(query))
                .Select(d => d.Manager_plant)
                .Distinct()
                .ToListAsync();
        }
    }
}

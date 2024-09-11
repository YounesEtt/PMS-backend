using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.Services
{
    public class scenarioItemsconfigurationservice
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;

        public scenarioItemsconfigurationservice(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration; // Initialisez IConfiguration
            _jwtSecret = _configuration["JwtConfig:Key"]; // Récupérez la clé secrète JWT à partir de la configuration
            _mapper = mapper;
        }


        public async Task<List<scenario_items_configurationDTO>> GetConfigurationsByScenario(int scenarioId)
        {
            var configurations = await _context.scenarioItemsConfiguration
                .Where(c => c.Id_scenario == scenarioId)
                .Include(c => c.RequestItem)
                .ToListAsync();

            return _mapper.Map<List<scenario_items_configurationDTO>>(configurations);
        }

        public async Task UpdateConfigurations(int scenarioId, List<scenario_items_configurationDTO> configurationsDto)
        {
            var configurations = _mapper.Map<List<scenario_items_configuration>>(configurationsDto);
            var existingConfigs = _context.scenarioItemsConfiguration.Where(c => c.Id_scenario == scenarioId);

            _context.scenarioItemsConfiguration.RemoveRange(existingConfigs);
            _context.scenarioItemsConfiguration.AddRange(configurations);
            await _context.SaveChangesAsync();
        }


        //CreatescenarioItemsConfiguration
        public async Task<scenario_items_configurationDTO> CreatescenarioItemsConfiguration(scenario_items_configurationDTO dto)
        {
            var entity = _mapper.Map<scenario_items_configuration>(dto);
            _context.scenarioItemsConfiguration.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<scenario_items_configurationDTO>(entity);
        }


        //GetAllscenarioItemsConfigurations
        public async Task<List<scenario_items_configurationDTO>> GetAllscenarioItemsConfigurations()
        {
            var scenarioItemsConfigurations = await _context.scenarioItemsConfiguration.ToListAsync();
            return _mapper.Map<List<scenario_items_configurationDTO>>(scenarioItemsConfigurations);
        }

        //GetscenarioItemsConfigurationById
        public async Task<scenario_items_configurationDTO> GetscenarioItemsConfigurationById(int id)
        {
            var scenarioItemsConfiguration = await _context.scenarioItemsConfiguration.FindAsync(id);
            return _mapper.Map<scenario_items_configurationDTO>(scenarioItemsConfiguration);
        }

        //UpdatescenarioItemsConfiguration
        public async Task<scenario_items_configurationDTO> UpdatescenarioItemsConfiguration(int id, scenario_items_configurationDTO dto)
        {
            var entity = _mapper.Map<scenario_items_configuration>(dto);
            entity.Id = id;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<scenario_items_configurationDTO>(entity);
        }

        //DeletescenarioItemsConfiguration
        public async Task<bool> DeletescenarioItemsConfiguration(int id)
        {
            var entity = await _context.scenarioItemsConfiguration.FindAsync(id);
            if (entity == null)
                return false;

            _context.scenarioItemsConfiguration.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

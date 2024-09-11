using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.Services
{
    public class ScenarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;

        public ScenarioService(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration; // Initialisez IConfiguration
            _jwtSecret = _configuration["JwtConfig:Key"]; // Récupérez la clé secrète JWT à partir de la configuration
            _mapper = mapper;
        }

        //CreateScenario
        public async Task<scenarioDTO> Createscenario(scenarioDTO dto)
        {
            var entity = _mapper.Map<scenario>(dto);
            _context.scenario.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<scenarioDTO>(entity);
        }

        // Get scenario attributes with isMandatory
        public async Task<List<scenarioItemsDTO>> GetScenarioAttributes(int scenarioId)
        {
            var scenarioItems = await _context.scenarioItemsConfiguration
                .Where(sic => sic.Id_scenario == scenarioId)
                .Select(sic => new scenarioItemsDTO
                {
                    AttributeName = _context.requestsItem.FirstOrDefault(ri => ri.Id_request_item == sic.Id_request_item).nameItem,
                    IsMandatory = sic.IsMandatory
                })
                .ToListAsync();

            return scenarioItems;
        }

        // Get approvers by scenario ID
        public async Task<List<approverScenarioDTO>> GetApproversByScenarioId(int scenarioId)
        {
            var approvers = await _context.Approverscenario
                .Where(a => a.scenarioId == scenarioId)
                .Select(a => new approverScenarioDTO
                {
                    role = a.role,
                    classe = a.classe
                })
                .ToListAsync();

            return approvers;
        }

        //GetAllScenarios
        public async Task<List<scenarioDTO>> GetAllScenarios()
        {
            var scenarios = await _context.scenario.ToListAsync();
            return _mapper.Map<List<scenarioDTO>>(scenarios);
        }

        //GetScenarioById
        public async Task<scenarioDTO> GetScenarioById(int id)
        {
            var scenario = await _context.scenario.FindAsync(id);
            return _mapper.Map<scenarioDTO>(scenario);
        }

        //UpdateScenario
        public async Task<scenarioDTO> UpdateScenario(int id, scenarioDTO dto)
        {
            var entity = _mapper.Map<scenario>(dto);
            entity.Id_scenario = id;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<scenarioDTO>(entity);
        }

        //DeleteScenario
        public async Task<bool> DeleteScenario(int id)
        {
            var entity = await _context.scenario.FindAsync(id);
            if (entity == null)
                return false;

            _context.scenario.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}


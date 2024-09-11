using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.Services
{
    public class ApproverScenarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;

        public ApproverScenarioService(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration; // Initialisez IConfiguration
            _jwtSecret = _configuration["JwtConfig:Key"]; // Récupérez la clé secrète JWT à partir de la configuration
            _mapper = mapper;
        }

        //create
        public async Task<approverScenarioDTO> CreateApprover(approverScenarioDTO dto)
        {
            var entity = _mapper.Map<approverscenario>(dto);
            _context.Approverscenario.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<approverScenarioDTO>(entity);
        }


        //
        public async Task<List<approverscenario>> GetAllApprovers()
        {
            var approvers = await _context.Approverscenario.ToListAsync();
            return approvers;
        }

        //
        public async Task<approverScenarioDTO> GetApproverById(int id)
        {
            var approver = await _context.Approverscenario.FindAsync(id);
            return _mapper.Map<approverScenarioDTO>(approver);
        }

        //update user
        public async Task<approverScenarioDTO> UpdateApprover(int id, approverScenarioDTO dto)
        {
            var entity = _mapper.Map<approverscenario>(dto);
            entity.id_approver = id;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<approverScenarioDTO>(entity);
        }

        //delete user
        public async Task<bool> DeleteApprover(int id)
        {
            var entity = await _context.Approverscenario.FindAsync(id);
            if (entity == null)
                return false;

            _context.Approverscenario.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

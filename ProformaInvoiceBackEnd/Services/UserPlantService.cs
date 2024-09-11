using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;

public class UserPlantService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserPlantService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserPlantDTO> CreateUserPlant(UserPlantDTO dto)
    {
        var userPlant = _mapper.Map<UserPlant>(dto);
        _context.userplant.Add(userPlant);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserPlantDTO>(userPlant);
    }

    public async Task<List<UserPlantDTO>> GetAllUserPlants()
    {
        var userPlants = await _context.userplant
            .Include(up => up.user)
            .Include(up => up.plant)
            .ToListAsync();
        return _mapper.Map<List<UserPlantDTO>>(userPlants);
    }

    public async Task<UserPlantDTO> GetUserPlantById(int id)
    {
        var userPlant = await _context.userplant
            .Include(up => up.user)
            .Include(up => up.plant)
            .FirstOrDefaultAsync(up => up.Id == id);
        if (userPlant == null) return null;
        return _mapper.Map<UserPlantDTO>(userPlant);
    }

    public async Task<bool> UpdateUserPlant(int id, UserPlantDTO dto)
    {
        var userPlant = await _context.userplant.FindAsync(id);
        if (userPlant == null) return false;

        _mapper.Map(dto, userPlant);
        _context.Entry(userPlant).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserPlant(int id)
    {
        var userPlant = await _context.userplant.FindAsync(id);
        if (userPlant == null) return false;

        _context.userplant.Remove(userPlant);
        await _context.SaveChangesAsync();
        return true;
    }
}

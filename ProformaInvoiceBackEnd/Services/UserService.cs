using ProformaInvoiceBackEnd.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using AutoMapper;
using ProformaInvoiceBackEnd.DTOs;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Login = ProformaInvoiceBackEnd.DTOs.Login;

namespace ProformaInvoiceBackEnd.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IConfiguration configuration, IMapper mapper) 
        {
            _context = context;
            _configuration = configuration; // Initialisez IConfiguration
            _jwtSecret = _configuration["JwtConfig:Key"]; // Récupérez la clé secrète JWT à partir de la configuration
            _mapper = mapper;
        }

        public async Task AddUserToPlant(int userId, int Id_plant)
        {
            var userPlant = new UserPlant
            {
                UserId = userId,
                Id_plant = Id_plant
            };
            _context.userplant.Add(userPlant);
            await _context.SaveChangesAsync();
        }

        public async Task<userDTO> CreateUser(CreateUserRequest request)
        {
            var userEntity = _mapper.Map<User>(request.User);
            _context.user.Add(userEntity);
            await _context.SaveChangesAsync();

            foreach (var plantId in request.plantId)
            {
                await AddUserToPlant(userEntity.UserId, plantId);
            }

            return _mapper.Map<userDTO>(userEntity);
        }

        //login 
        public string LoginUser(Login login)
        {
            User userAvailable = null;
            if (login.Identifier.Contains("@")) // Checks if the identifier is likely an email
            {
                userAvailable = _context.user.FirstOrDefault(u => u.email == login.Identifier && u.Pwd == login.password);
            }
            else
            {
                userAvailable = _context.user.FirstOrDefault(u => u.TeId == login.Identifier && u.Pwd == login.password);
            }

            if (userAvailable != null && !string.IsNullOrWhiteSpace(userAvailable.Role))
            {
                var userDto = _mapper.Map<userDTO>(userAvailable);
                var token = GenerateToken(userDto);
                return token;
            }
            return "Failure";
        }

        //token generation
        public string GenerateToken(userDTO user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var identity = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("id", user.userId.ToString())
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        // Get all users
        public async Task<List<userDTO>> GetAllUsers()
        {
            var users = await _context.user
                .Include(u => u.UserPlants)
                .ThenInclude(up => up.plant)
                .ToListAsync();
            return _mapper.Map<List<userDTO>>(users);
        }

        public async Task<UserWithPlantsDTO> GetUserById(int id)
        {
            var user = await _context.user
                .Include(u => u.UserPlants)
                .ThenInclude(up => up.plant)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return null;
            }

            var userDto = _mapper.Map<userDTO>(user);
            var plantIds = user.UserPlants.Select(up => up.Id_plant).ToList();

            return new UserWithPlantsDTO
            {
                User = userDto,
                PlantIds = plantIds
            };
        }

        public async Task<User> Update(int id, UpdateUserDTO request)
        {
            try
            {
                var entity = await _context.user.Include(u => u.UserPlants).FirstOrDefaultAsync(u => u.UserId == id);
                if (entity == null)
                {
                    return null;
                }

                // Mettre à jour les propriétés de l'utilisateur
                entity.TeId = request.TeId;
                entity.UserName = request.UserName;
                entity.email = request.email;
                entity.nPlus1 = request.nPlus1;
                entity.BackUp = request.BackUp;
                entity.Role = request.Role;
                entity.DepartementId = request.DepartementId;

                _context.Entry(entity).State = EntityState.Modified;

                // Mettre à jour les plants
                var existingUserPlants = _context.userplant.Where(up => up.UserId == id).ToList();
                _context.userplant.RemoveRange(existingUserPlants);

                if (request.plantId != null)
                {
                    foreach (var plantId in request.plantId)
                    {
                        await AddUserToPlant(id, plantId);
                    }
                }

                await _context.SaveChangesAsync();
                return _mapper.Map<User>(entity);
            }
            catch (Exception ex)
            {
                // Log the error (you can use any logging framework)
                Console.WriteLine($"Une erreur s'est produite lors de la mise à jour de l'utilisateur : {ex.InnerException?.Message ?? ex.Message}");
                throw;
            }
        }
        //delete user
        public async Task<bool> Delete(int id)
        {
            // Trouver toutes les associations userplant pour l'utilisateur spécifié
            var userPlants = _context.userplant.Where(up => up.UserId == id).ToList();

            // Supprimer toutes les entrées trouvées
            if (userPlants.Any())
            {
                _context.userplant.RemoveRange(userPlants);
                await _context.SaveChangesAsync();
            }

            // Trouver l'utilisateur par son ID
            var user = await _context.user.FindAsync(id);
            if (user == null)
                return false;

            // Supprimer l'utilisateur
            _context.user.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
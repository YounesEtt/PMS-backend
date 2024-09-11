using Humanizer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;
using ProformaInvoiceBackEnd.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularApp")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly UserPlantService _userPlantService;

        public UserController(UserService userService)
        {
            _userService = userService;
            
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<userDTO>> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var createdUser = await _userService.CreateUser(request);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'utilisateur: {ex.Message}");
            }
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<string>> Login(Login login)
        {
            var token = _userService.LoginUser(login);
            if (token != "Failure")
            {
                return Ok(new { Token = token });
            }
            return BadRequest("Authentication failed");
        }

        // Get all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userDTO>>> GetAllUsers()
        {
            try
            {
                var items = await _userService.GetAllUsers();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        // Get user by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<UserWithPlantsDTO>> GetUserById(int id)
        {
            try
            {
                var item = await _userService.GetUserById(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        // Update user 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO request)
        {
            try
            {
                Console.WriteLine($"Received payload for user update: {JsonConvert.SerializeObject(request)}");

                var updatedItem = await _userService.Update(id, request);
                if (updatedItem == null)
                {
                    return NotFound($"Utilisateur avec l'ID {id} non trouvé.");
                }
                return NoContent();
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Erreur de mise à jour de la base de données : {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la mise à jour de l'élément : {ex.InnerException?.Message ?? ex.Message}");
            }
        }




        //delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _userService.Delete(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la suppression de l'élément : {ex.Message}");
            }
        }

    }

}


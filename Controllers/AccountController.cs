using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using EstudoDotNet.Services;
using EstudoDotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace EstudoDotNet.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AccountController(TokenService tokenService)
        {
            _tokenService = tokenService;    
        }

        [HttpPost("v1/accounts")]
        public async Task<IActionResult> Post(
            [FromBody]RegisterViewModel model,
            [FromServices] BlogDataContext context
        )
        {

            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };

            var password = PasswordGenerator.Generate(25);
            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(
                    new
                    {
                        user = user.Email, 
                        password
                    }
                ));
            }
            catch(DbUpdateException ex)
            {
                return StatusCode(400, new ResultViewModel<string>(ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(400, new ResultViewModel<string>("Erro interno no servidor"));
            }
        }

        [HttpPost("v1/accounts/login")]
        public IActionResult Login()
        {
            var token = _tokenService.GenerateToken(null);

            return Ok(token);
        }
    }
}
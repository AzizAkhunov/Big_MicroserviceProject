using GAI.Application.Interfaces;
using GAI.Domain.Model;
using GAI.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GAI.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly GAIDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(GAIDbContext dbContext, ITokenService tokenService)
        {
            _context = dbContext;
            _tokenService = tokenService;
        }

        public async ValueTask<string> Login(RequestLogin request)
        {
            var user = await _context.GAies.FirstOrDefaultAsync(x => x.UserName == request.UserName);

            if (user is null)
            {
                throw new Exception("User not Found");
            }
            else if (user.Password != request.Password)
            {
                throw new Exception("Password is wrong!!");
            }
            return _tokenService.Generate(user.UserName);
        }
    }
}

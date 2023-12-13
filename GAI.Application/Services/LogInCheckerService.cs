using GAI.Infastructure.DbContexts;

namespace GAI.Application.Services
{
    public class LogInCheckerService
    {
        private readonly GAIDbContext _context;
        public bool LogInChecker(string account, string password)
        {
            var check = _context.GAies.FirstOrDefault(x => x.UserName == account && x.Password == password);
            if (check is not null)
            {
                return true;
            }
            return false;
        }
    }
}

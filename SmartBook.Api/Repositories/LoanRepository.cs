using SmartBook.Database.Data;
using SmartBook.Database.Models;

namespace SmartBook.Api.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any specific methods for Loan entity here
    }
}

using ERPSystem.Data;
using ERPSystem.Models.Finance;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace ERPSystem.Services
{
    public class FinanceService
    {
        private readonly ApplicationDbContext _context;
        public FinanceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        } 
        public decimal ReconcileTransactions(IEnumerable<Transaction> transactions)
        {
            decimal total = 0;
            foreach (var tx in transactions)
            {
                total += tx.Amount;
            }
            return total;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly UserDBContext _context;

        public TransactionsController(UserDBContext context)
        {
            _context = context;
        }

        // GET: Transactions
        [HttpGet("Transactions")]
        public async Task<ActionResult<IEnumerable<Transaction>>> Index()
        {
            return await _context.Transactions.ToListAsync();
        }

        // GET: Transactions/Details/5
        [HttpGet("Transactions/Details/{id}")]
        public async Task<ActionResult<Transaction>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // POST: Transactions/Create
        [HttpPost("Transactions/Create")]
        public async Task<ActionResult<Transaction>> Create([Bind("Id,UserId,BoughtCurrencyId,BoughtCurrencyQuantity,SoldCurrencyId,SoldCurrencyQuantity")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return transaction;
        }

        // GET: Transactions/Edit/5
        [HttpGet("Transactions/Edit/{id}")]
        public async Task<ActionResult<Transaction>> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return transaction;
        }

        // POST: Transactions/Edit/5
        [HttpPost("Transactions/Edit/{id}")]
        public async Task<ActionResult<Transaction>> Edit(int id, [Bind("Id,UserId,BoughtCurrencyId,BoughtCurrencyQuantity,SoldCurrencyId,SoldCurrencyQuantity")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return transaction;
        }

        // POST: Transactions/Delete/5
        [HttpPost("Transactions/Delete/{id}"), ActionName("Delete")]
        public async Task<ActionResult<int>> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return id;
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
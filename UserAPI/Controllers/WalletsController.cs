using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    public class WalletsController : Controller
    {
        private readonly UserDBContext _context;

        public WalletsController(UserDBContext context)
        {
            _context = context;
        }

        // GET: Wallets
        [HttpGet("Wallets")]
        public async Task<ActionResult<IEnumerable<Wallet>>> Index()
        {
            return await _context.Wallets.ToListAsync();
        }

        // GET: Wallets/Details/5
        [HttpGet("Wallets/Details/{id}")]
        public async Task<ActionResult<Wallet>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wallet == null)
            {
                return NotFound();
            }

            return wallet;
        }

        // POST: Wallets/Create
        [HttpPost("Wallets/Create")]
        public async Task<ActionResult<Wallet>> Create([Bind("Id,UserId,CurrencyID,Quantity")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wallet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return wallet;
        }

        // POST: Wallets/Edit/5
        [HttpPut("Wallets/Edit/{id}")]
        public async Task<ActionResult<Wallet>> Edit(int id, [Bind("Id,UserId,CurrencyID,Quantity")] Wallet wallet)
        {
            if (id != wallet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wallet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletExists(wallet.Id))
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
            return wallet;
        }

        // POST: Wallets/Delete/5
        [HttpDelete("Wallets/Delete/{id}"), ActionName("Delete")]
        public async Task<ActionResult<int>> DeleteConfirmed(int id)
        {
            var wallet = await _context.Wallets.FindAsync(id);
            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();
            return id;
        }

        private bool WalletExists(int id)
        {
            return _context.Wallets.Any(e => e.Id == id);
        }
    }
}
using testmvcapp.Data;
using testmvcapp.Repositories.Interfaces;
using testmvcapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace testmvcapp.Repositories;

public class CoinRepository : ICoinRepository
{
    private readonly TestDbContext _context;
    public CoinRepository(TestDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Coin>> GetCoinsAsync()
    {
        return await _context.Coins.OrderByDescending(c => c.Denomination).ToListAsync();
    }

    public async Task<Coin?> GetByDenominationAsync(int denomination)
    {
        return await _context.Coins.FirstOrDefaultAsync(c => c.Denomination == denomination);
    }

    public void UpdateCoin(Coin coin)
    {
        _context.Coins.Update(coin);
    }

    public async Task SaveCoinChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Coin>> GetAvailableCoinsAsync() // !!!ТУТ ЧЕТО СТРАННО!!!
    {
        return await _context.Coins.Where(c => c.Quantity > 0).ToListAsync();
    }
}
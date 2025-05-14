using testmvcapp.Services.Interfaces;
using testmvcapp.Repositories.Interfaces;
using testmvcapp.Models;
using AspNetCoreGeneratedDocument;

namespace testmvcapp.Services;


public class CoinService : ICoinService
{
    private readonly ICoinRepository _coinRepository;

    public CoinService(ICoinRepository coinRepository)
    {
        _coinRepository = coinRepository;
    }

    public async Task<IEnumerable<Coin>> GetCoinsAsync()
    {
        return await _coinRepository.GetCoinsAsync();
    }

    public async Task<Coin?> GetByDenominationAsync(int denomination)
    {
        return await _coinRepository.GetByDenominationAsync(denomination);
    }

    public async Task AddCoinsAsync(Dictionary<int, int> insertedCoins)
    {
        foreach (var (denomination, quantity) in insertedCoins)
        {
            var coin = await _coinRepository.GetByDenominationAsync(denomination);
            if (coin != null)
            {
                coin.Quantity += quantity;
                _coinRepository.UpdateCoin(coin);
            }
        }
        await _coinRepository.SaveCoinChangesAsync();
    }

    public async Task<bool> TryTakeChangeAsync(Dictionary<int, int> changeCoins)
    {
        foreach (var (denomination, quantity) in changeCoins)
        {
            var coin = await _coinRepository.GetByDenominationAsync(denomination);
            if (coin == null || coin.Quantity < quantity)
            {
                return false;
            }
        }

        foreach (var (denomination, quantity) in changeCoins)
        {
            var coin = await _coinRepository.GetByDenominationAsync(denomination);
            if (coin != null)
            {
                coin.Quantity -= quantity;
                _coinRepository.UpdateCoin(coin);
            }
        }

        await _coinRepository.SaveCoinChangesAsync();
        return true;
    }
}

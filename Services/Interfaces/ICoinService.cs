using testmvcapp.Models;
namespace testmvcapp.Services.Interfaces;
public interface ICoinService
{
    Task<IEnumerable<Coin>> GetCoinsAsync();
    Task<Coin?> GetByDenominationAsync(int denomination);
    Task AddCoinsAsync(Dictionary<int, int> insertedCoins);
    // Task<bool> TryGiveChangeAsync(int changeAmountm, out Dictionary<int, int> change);
    Task<bool> TryTakeChangeAsync(Dictionary<int, int> changeCoins);
}

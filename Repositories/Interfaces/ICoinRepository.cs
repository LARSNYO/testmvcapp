using testmvcapp.Models;

namespace testmvcapp.Repositories.Interfaces;

public interface ICoinRepository
{
    /// <summary>
    /// Получить список всех монет
    /// </summary>
    Task<IEnumerable<Coin>> GetCoinsAsync();

    /// <summary>
    /// Получить номинал монеты
    /// </summary>
    Task<Coin?> GetByDenominationAsync(int denomination);

    /// <summary>
    /// Обновить/изменить
    /// </summary>
    void UpdateCoin(Coin coin);

    /// <summary>
    /// Сохранить изменения 
    /// </summary>
    Task SaveCoinChangesAsync();

    Task<IEnumerable<Coin>> GetAvailableCoinsAsync(); // !!! ТУТ СТРАННО ЧЕТ!!!


}
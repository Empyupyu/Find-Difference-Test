using UnityEngine.Purchasing;

public class IAPSystem : GameSystem
{
    public void OnPurchase(Product product)
    {
        switch (product.definition.id)
        {
            case "buy_time_10":
                _gameData.CurrentTimer += (float)product.definition.payout.quantity;
                break;

            default:
                break;
        }      
    }
}

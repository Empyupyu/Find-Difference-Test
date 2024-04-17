using UnityEngine.Purchasing;

public class IAPSystem : GameSystem
{
    public void OnPurchase(Product product)
    {
        switch (product.definition.id)
        {
            case "buy_time_10":
                PurhcaseTime((float)product.definition.payout.quantity);
                break;

            default:
                break;
        }      
    }

    public void FakePurchase()
    {
#if (!UNITY_EDITOR)
        PurhcaseTime(10f);
#endif
    }

    private void PurhcaseTime(float value)
    {
        _gameData.CurrentTimer += value;
    }
}

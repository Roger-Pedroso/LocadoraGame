using UnityEngine;
using UnityEngine.UI;

public class ShopItemCard : MonoBehaviour
{
    public Image iconImage;
    public Text titleText;
    public Text priceText;
    public Button buyButton;

    private string gameId;
    private int price;

    public void Setup(string id, string title, int price, string rank)
    {
        this.gameId = id;
        this.price = price;
        titleText.text = title + " [" + rank + "]";
        priceText.text = price + " coins";
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(OnBuy);
    }

    void OnBuy()
    {
        // TODO: call ShopManager or PlayerMoney to process purchase
        Debug.Log($"Buy requested: {gameId} for {price}");
    }
}

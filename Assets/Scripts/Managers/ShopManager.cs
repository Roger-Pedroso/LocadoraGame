using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private static ShopManager _instance;
    public static ShopManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("ShopManager");
                _instance = obj.AddComponent<ShopManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public GameDatabase database;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            if (database == null)
            {
                database = Resources.Load<GameDatabase>("GameDatabase");
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool BuyGame(string gameId)
    {
        if (database == null) database = Resources.Load<GameDatabase>("GameDatabase");
        var g = database?.GetById(gameId);
        if (g == null)
        {
            Debug.LogWarning($"Game {gameId} not found in database");
            return false;
        }

        if (!PlayerMoney.Instance.CanAfford(g.purchasePrice))
        {
            Debug.Log("Not enough money");
            return false;
        }

        var ok = PlayerMoney.Instance.Spend(g.purchasePrice);
        if (!ok) return false;

        InventoryManager.Instance.AddGame(gameId, 1);
        Debug.Log($"Purchased {g.title} for {g.purchasePrice}");
        return true;
    }
}

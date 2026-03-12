using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameShopUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject shopItemPrefab;

    private List<GameObject> spawned = new List<GameObject>();

    void Start()
    {
        RefreshCatalog();
    }

    public void RefreshCatalog()
    {
        ClearCatalog();
        // Fallback: try load shop prefab from Resources if not assigned
        if (shopItemPrefab == null)
        {
            var fallback = Resources.Load<GameObject>("Prefabs/ShopItemCard");
            if (fallback != null) shopItemPrefab = fallback;
        }

        var db = Resources.Load<GameDatabase>("GameDatabase");
        if (db == null) return;
        var games = db.GetAll();
        foreach (var g in games)
        {
            if (shopItemPrefab == null) break;
            var card = Instantiate(shopItemPrefab, contentParent);
            var comp = card.GetComponent<ShopItemCard>();
            if (comp != null)
            {
                comp.Setup(g.id, g.title, g.purchasePrice, g.rank.ToString());
            }
            spawned.Add(card);
        }
    }

    void ClearCatalog()
    {
        foreach (var g in spawned) Destroy(g);
        spawned.Clear();
    }
}

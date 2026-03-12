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
        // TODO: load GameDatabase from Resources or assigned reference
        var db = Resources.Load<ScriptableObject>("GameDatabase") as dynamic;
        if (db == null) return;
        var games = db.GetAll() as List<dynamic>;
        foreach (var g in games)
        {
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

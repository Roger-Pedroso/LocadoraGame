using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.PrefabUtility;

public static class CreateUIPrefabs
{
    [MenuItem("Locadora/Create UI Prefabs")]
    public static void Create()
    {
        // Ensure folders
        System.IO.Directory.CreateDirectory("Assets/Prefabs");
        System.IO.Directory.CreateDirectory("Assets/Resources/Prefabs");

        // InventoryItemCard prefab
        var invRoot = new GameObject("InventoryItemCard");
        var rt = invRoot.AddComponent<RectTransform>();
        invRoot.AddComponent<UnityEngine.CanvasRenderer>();
        invRoot.AddComponent<UnityEngine.UI.Image>();
        invRoot.AddComponent<InventoryItemCard>();

        var icon = new GameObject("Icon");
        icon.transform.SetParent(invRoot.transform);
        var iconRt = icon.AddComponent<RectTransform>();
        var iconImg = icon.AddComponent<UnityEngine.UI.Image>();

        var title = new GameObject("Title");
        title.transform.SetParent(invRoot.transform);
        var titleText = title.AddComponent<UnityEngine.UI.Text>();
        titleText.text = "Game Title";

        var durability = new GameObject("Durability");
        durability.transform.SetParent(invRoot.transform);
        var durText = durability.AddComponent<UnityEngine.UI.Text>();
        durText.text = "Durability: 100%";

        var copies = new GameObject("Copies");
        copies.transform.SetParent(invRoot.transform);
        var copiesText = copies.AddComponent<UnityEngine.UI.Text>();
        copiesText.text = "1 copy";

        var inspectBtn = new GameObject("InspectButton");
        inspectBtn.transform.SetParent(invRoot.transform);
        var btn = inspectBtn.AddComponent<UnityEngine.UI.Button>();
        var btnText = new GameObject("Text").AddComponent<UnityEngine.UI.Text>();
        btnText.text = "Inspect";
        btnText.transform.SetParent(inspectBtn.transform);

        // Assign InventoryItemCard component references if possible
        var invComp = invRoot.GetComponent<InventoryItemCard>();
        if (invComp != null)
        {
            invComp.iconImage = iconImg;
            invComp.titleText = titleText;
            invComp.durabilityText = durText;
            invComp.copiesText = copiesText;
            invComp.inspectButton = btn;
        }

        string invPath = "Assets/Prefabs/InventoryItemCard.prefab";
        PrefabUtility.SaveAsPrefabAsset(invRoot, invPath);
        var resInvPath = "Assets/Resources/Prefabs/InventoryItemCard.prefab";
        PrefabUtility.SaveAsPrefabAsset(invRoot, resInvPath);
        GameObject.DestroyImmediate(invRoot);

        // ShopItemCard prefab
        var shopRoot = new GameObject("ShopItemCard");
        var rt2 = shopRoot.AddComponent<RectTransform>();
        shopRoot.AddComponent<UnityEngine.CanvasRenderer>();
        shopRoot.AddComponent<UnityEngine.UI.Image>();
        shopRoot.AddComponent<ShopItemCard>();

        var sTitle = new GameObject("Title");
        sTitle.transform.SetParent(shopRoot.transform);
        var sTitleText = sTitle.AddComponent<UnityEngine.UI.Text>();
        sTitleText.text = "Title [Rank]";

        var sPrice = new GameObject("Price");
        sPrice.transform.SetParent(shopRoot.transform);
        var sPriceText = sPrice.AddComponent<UnityEngine.UI.Text>();
        sPriceText.text = "100 coins";

        var buyBtn = new GameObject("BuyButton");
        buyBtn.transform.SetParent(shopRoot.transform);
        var buyButton = buyBtn.AddComponent<UnityEngine.UI.Button>();
        var buyBtnText = new GameObject("Text").AddComponent<UnityEngine.UI.Text>();
        buyBtnText.text = "Buy";
        buyBtnText.transform.SetParent(buyBtn.transform);

        var shopComp = shopRoot.GetComponent<ShopItemCard>();
        if (shopComp != null)
        {
            shopComp.titleText = sTitleText;
            shopComp.priceText = sPriceText;
            shopComp.buyButton = buyButton;
        }

        string shopPath = "Assets/Prefabs/ShopItemCard.prefab";
        PrefabUtility.SaveAsPrefabAsset(shopRoot, shopPath);
        var resShopPath = "Assets/Resources/Prefabs/ShopItemCard.prefab";
        PrefabUtility.SaveAsPrefabAsset(shopRoot, resShopPath);
        GameObject.DestroyImmediate(shopRoot);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Created InventoryItemCard and ShopItemCard prefabs in Assets/Prefabs and Assets/Resources/Prefabs");
    }
}

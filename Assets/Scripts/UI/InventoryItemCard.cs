using UnityEngine;
using UnityEngine.UI;

public class InventoryItemCard : MonoBehaviour
{
    public Image iconImage;
    public Text titleText;
    public Text durabilityText;
    public Text copiesText;
    public Button inspectButton;

    private string uid;

    public void Setup(string gameId, string uid, int durability)
    {
        this.uid = uid;
        // populate title from GameDatabase if available
        var db = Resources.Load<GameDatabase>("GameDatabase");
        var gd = db != null ? db.GetById(gameId) : null;
        titleText.text = gd != null ? gd.title : gameId;
        durabilityText.text = $"Durability: {durability}%";
        copiesText.text = "1 copy";

        UpdateDurabilityVisual(durability);

        if (inspectButton != null)
        {
            inspectButton.onClick.RemoveAllListeners();
            inspectButton.onClick.AddListener(OnInspect);
        }
    }

    void UpdateDurabilityVisual(int durability)
    {
        // change color of durability text as simple visual cue
        if (durability >= 60)
            durabilityText.color = Color.green;
        else if (durability >= 20)
            durabilityText.color = Color.yellow;
        else
            durabilityText.color = Color.red;
    }

    public void OnInspect()
    {
        Debug.Log($"Inspecting {uid}");
        // TODO: open a popup with game details (title, description, repair options)
    }

    public void UpdateDurability(int newDurability)
    {
        durabilityText.text = $"Durability: {newDurability}%";
        UpdateDurabilityVisual(newDurability);
    }
}

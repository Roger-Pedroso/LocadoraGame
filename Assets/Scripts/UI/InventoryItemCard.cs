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
        var db = Resources.Load<ScriptableObject>("GameDatabase") as dynamic;
        // safer approach: use a GameDatabase reference provided via InventoryUI (TODO)
        // For now, show raw info
        titleText.text = gameId;
        durabilityText.text = $"Durability: {durability}%";
        copiesText.text = "1 copy";
    }

    public void OnInspect()
    {
        // TODO: open a popup with game details
        Debug.Log($"Inspecting {uid}");
    }
}

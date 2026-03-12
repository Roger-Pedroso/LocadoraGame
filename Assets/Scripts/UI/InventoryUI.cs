using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform contentParent; // parent for item cards (e.g., Content of ScrollRect)
    public GameObject itemCardPrefab; // prefab for a game item card
    public Dropdown platformFilter; // dropdown for platform filter
    public Dropdown rankFilter; // dropdown for rank filter

    private List<GameObject> spawned = new List<GameObject>();

    void Start()
    {
        RefreshList();
    }

    public void RefreshList()
    {
        ClearList();
        var copies = InventoryManager.Instance.GetAllCopies();
        foreach (var copy in copies)
        {
            var card = Instantiate(itemCardPrefab, contentParent);
            var cardComp = card.GetComponent<InventoryItemCard>();
            if (cardComp != null)
            {
                cardComp.Setup(copy.gameId, copy.uid, copy.durability);
            }
            spawned.Add(card);
        }
    }

    public void ClearList()
    {
        foreach (var g in spawned) Destroy(g);
        spawned.Clear();
    }

    public void OnPlatformFilterChanged(int index)
    {
        // TODO: apply platform filtering by re-querying InventoryManager and GameDatabase
        RefreshList();
    }

    public void OnRankFilterChanged(int index)
    {
        // TODO: apply rank filtering
        RefreshList();
    }
}

using UnityEngine;
using System;

public class RentalManager : MonoBehaviour
{
    private static RentalManager _instance;
    public static RentalManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("RentalManager");
                _instance = obj.AddComponent<RentalManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public event Action<string, string> OnRentSuccess; // gameId, copyUid
    public event Action<string> OnRentFailedNoCopies; // gameId
    public event Action<string, string> OnCopyCritical; // gameId, copyUid
    public event Action<string, string> OnCopyBroken; // gameId, copyUid

    [Tooltip("Default wear amount per rental (durability points)")]
    public int defaultWear = 5;

    public bool Rent(string gameId)
    {
        var copy = InventoryManager.Instance.RentCopy(gameId, defaultWear);
        if (copy == null)
        {
            OnRentFailedNoCopies?.Invoke(gameId);
            Debug.LogWarning($"No available copies to rent: {gameId}");
            return false;
        }

        // Notify success
        OnRentSuccess?.Invoke(gameId, copy.uid);

        // If critical or broken, raise events
        if (copy.durability == 0)
            OnCopyBroken?.Invoke(gameId, copy.uid);
        else if (copy.durability < 20)
            OnCopyCritical?.Invoke(gameId, copy.uid);

        Debug.Log($"Rented copy {copy.uid} of {gameId}. Durability now {copy.durability}%");
        return true;
    }
}

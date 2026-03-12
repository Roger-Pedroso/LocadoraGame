using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[System.Serializable]
public class GameCopy
{
    public string gameId;
    public int durability;
    public string uid;
}

using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[System.Serializable]
public class GameCopy
{
    public string gameId;
    public int durability;
    public string uid;
}

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("InventoryManager");
                _instance = obj.AddComponent<InventoryManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public event Action OnInventoryChanged;
    public event Action<GameCopy> OnCopyDurabilityChanged;
    public event Action<GameCopy> OnCopyBecameCritical;
    public event Action<GameCopy> OnCopyBecameBroken;

    private Dictionary<string, List<GameCopy>> copies = new Dictionary<string, List<GameCopy>>();
    private string saveFile => Path.Combine(Application.persistentDataPath, "inventory.json");

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            Load();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddGame(string gameId, int quantity = 1)
    {
        if (!copies.ContainsKey(gameId)) copies[gameId] = new List<GameCopy>();
        for (int i = 0; i < quantity; i++)
        {
            var copy = new GameCopy() { gameId = gameId, durability = 100, uid = System.Guid.NewGuid().ToString() };
            copies[gameId].Add(copy);
            OnCopyDurabilityChanged?.Invoke(copy);
        }
        Save();
    }

    public bool RemoveGame(string uid)
    {
        foreach (var kv in copies)
        {
            var item = kv.Value.Find(c => c.uid == uid);
            if (item != null)
            {
                kv.Value.Remove(item);
                if (kv.Value.Count == 0) copies.Remove(kv.Key);
                Save();
                return true;
            }
        }
        return false;
    }

    public int GetAvailableCopies(string gameId)
    {
        if (copies.TryGetValue(gameId, out var list)) return list.Count(c => c.durability > 0);
        return 0;
    }

    public List<GameCopy> GetAllCopies()
    {
        var all = new List<GameCopy>();
        foreach (var l in copies.Values) all.AddRange(l);
        return all;
    }

    public GameCopy RentCopy(string gameId, int wearAmount = 5)
    {
        // find a copy with durability > 0
        if (!copies.TryGetValue(gameId, out var list)) return null;
        var usable = list.Find(c => c.durability > 0);
        if (usable == null) return null;

        usable.durability = Mathf.Max(0, usable.durability - wearAmount);
        OnCopyDurabilityChanged?.Invoke(usable);
        if (usable.durability == 0)
            OnCopyBecameBroken?.Invoke(usable);
        else if (usable.durability < 20)
            OnCopyBecameCritical?.Invoke(usable);

        Save();
        return usable;
    }

    public void DamageCopy(string uid, int amount)
    {
        foreach (var kv in copies)
        {
            var item = kv.Value.Find(c => c.uid == uid);
            if (item != null)
            {
                item.durability = Mathf.Max(0, item.durability - amount);
                OnCopyDurabilityChanged?.Invoke(item);
                if (item.durability == 0) OnCopyBecameBroken?.Invoke(item);
                else if (item.durability < 20) OnCopyBecameCritical?.Invoke(item);
                Save();
                break;
            }
        }
    }

    void Save()
    {
        try
        {
            var wrapper = new SerializationWrapper { items = GetAllCopies().ToArray() };
            var json = JsonUtility.ToJson(wrapper);
            File.WriteAllText(saveFile, json);
            OnInventoryChanged?.Invoke();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    void Load()
    {
        copies.Clear();
        if (!File.Exists(saveFile))
        {
            OnInventoryChanged?.Invoke();
            return;
        }
        try
        {
            var json = File.ReadAllText(saveFile);
            var wrapper = JsonUtility.FromJson<SerializationWrapper>(json);
            if (wrapper?.items != null)
            {
                foreach (var c in wrapper.items)
                {
                    if (!copies.ContainsKey(c.gameId)) copies[c.gameId] = new List<GameCopy>();
                    copies[c.gameId].Add(c);
                }
            }
            OnInventoryChanged?.Invoke();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    [System.Serializable]
    class SerializationWrapper { public GameCopy[] items; }
}

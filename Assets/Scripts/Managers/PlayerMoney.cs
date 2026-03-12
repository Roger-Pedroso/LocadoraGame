using UnityEngine;
using System;
using System.IO;

public class PlayerMoney : MonoBehaviour
{
    private static PlayerMoney _instance;
    public static PlayerMoney Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("PlayerMoney");
                _instance = obj.AddComponent<PlayerMoney>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public event Action<int> OnMoneyChanged;

    private int balance = 200; // default
    private string saveFile => Path.Combine(Application.persistentDataPath, "player_money.json");

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

    public int GetBalance() => balance;

    public bool CanAfford(int amount) => balance >= amount;

    public bool Spend(int amount)
    {
        if (!CanAfford(amount)) return false;
        balance -= amount;
        Save();
        OnMoneyChanged?.Invoke(balance);
        return true;
    }

    public void Add(int amount)
    {
        balance += amount;
        Save();
        OnMoneyChanged?.Invoke(balance);
    }

    void Save()
    {
        try
        {
            File.WriteAllText(saveFile, balance.ToString());
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    void Load()
    {
        try
        {
            if (File.Exists(saveFile))
            {
                var txt = File.ReadAllText(saveFile);
                if (int.TryParse(txt, out var val)) balance = val;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
        OnMoneyChanged?.Invoke(balance);
    }
}

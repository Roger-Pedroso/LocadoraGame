using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameDatabase", menuName = "Locadora/GameDatabase", order = 2)]
public class GameDatabase : ScriptableObject
{
    public List<GameData> games = new List<GameData>();

    private Dictionary<string, GameData> lookup;

    private void OnEnable()
    {
        BuildLookup();
    }

    public void BuildLookup()
    {
        lookup = new Dictionary<string, GameData>();
        foreach (var g in games)
        {
            if (g != null && !string.IsNullOrEmpty(g.id))
                lookup[g.id] = g;
        }
    }

    public GameData GetById(string id)
    {
        if (lookup == null) BuildLookup();
        lookup.TryGetValue(id, out var g);
        return g;
    }

    public List<GameData> GetAll()
    {
        return games;
    }
}

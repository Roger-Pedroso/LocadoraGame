using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public static class SeedGameDatabase
{
    [MenuItem("Locadora/Seed Game Database")]
    public static void Seed()
    {
        var games = new List<(string id, string title, string genre, string rank, int purchase, int rental, int durability)>
        {
            ("crash_warped","Crash Bandicoot 3: Warped","Platform","D",50,3,80),
            ("tony_hawk_2","Tony Hawk's Pro Skater 2","Sports","D",50,3,75),
            ("tekken_3","Tekken 3","Fighting","D",55,4,80),
            ("residentevil_2","Resident Evil 2","Horror","D",60,4,70),
            ("megaman_x5","Mega Man X5","Action","D",45,3,80),
            ("ace_combat_3","Ace Combat 3","Action","D",50,3,75),
            ("gta_original","Grand Theft Auto","ActionOpen","C",80,5,85),
            ("metal_gear_solid","Metal Gear Solid","Action","C",85,6,85),
            ("ff7_port","Final Fantasy VII","RPG","C",90,6,80),
            ("spyro","Spyro the Dragon","Platform","C",65,4,80),
            ("ape_escape","Ape Escape","ActionAdventure","C",75,5,80),
            ("rayman2","Rayman 2","Platform","C",70,4,80),
            ("street_fighter_alpha3","Street Fighter Alpha 3","Fighting","C",70,5,80),
            ("winning_eleven_2001","Winning Eleven 2001","Sports","C",65,4,75),
            ("dbz_budokai","Dragon Ball Z: Budokai","Fighting","B",110,7,85),
            ("burnout_3","Burnout 3: Takedown","Racing","B",120,8,85),
            ("devil_may_cry","Devil May Cry","Action","B",130,8,85),
            ("gta_san_andreas","GTA: San Andreas","ActionOpen","B",150,10,90),
            ("god_of_war_ii","God of War II","ActionAdventure","B",140,9,85),
            ("kingdom_hearts","Kingdom Hearts","RPG","B",135,9,85)
        };

        string baseFolder = "Assets/ScriptableObjects/GameData";
        System.IO.Directory.CreateDirectory(baseFolder);

        var createdAssets = new List<GameData>();

        foreach (var g in games)
        {
            var data = ScriptableObject.CreateInstance<GameData>();
            data.id = g.id;
            data.title = g.title;
            data.platform = PlatformType.PS2;
            // rank parsing
            try { data.rank = (RankType)System.Enum.Parse(typeof(RankType), g.rank); } catch { data.rank = RankType.D; }

            // genre best-effort
            GenreType genreEnum = GenreType.Other;
            System.Enum.TryParse(g.genre.Replace("ActionAdventure","Adventure").Replace("ActionOpen","Action"), out genreEnum);
            data.genre = genreEnum;
            data.purchasePrice = g.purchase;
            data.rentalPrice = g.rental;
            data.maxDurability = g.durability;
            data.description = g.title + " — placeholder description.";

            string assetPath = System.IO.Path.Combine(baseFolder, g.id + ".asset");
            AssetDatabase.CreateAsset(data, assetPath);
            createdAssets.Add(data);
        }

        // Create GameDatabase asset
        string dbFolder = "Assets/ScriptableObjects";
        System.IO.Directory.CreateDirectory(dbFolder);
        var db = ScriptableObject.CreateInstance<GameDatabase>();
        db.games = new List<GameData>(createdAssets);
        string dbPath = System.IO.Path.Combine(dbFolder, "GameDatabase.asset");
        AssetDatabase.CreateAsset(db, dbPath);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"Seeded {createdAssets.Count} GameData assets and GameDatabase at {dbPath}");
    }
}

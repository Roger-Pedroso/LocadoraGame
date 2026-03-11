using UnityEngine;

public enum PlatformType { PS2, PS3, Xbox360 }
public enum RankType { S, A, B, C, D }
public enum GenreType { Action, Adventure, RPG, Sports, Racing, Fighting, Horror, Shooter, Puzzle, Other }

[CreateAssetMenu(fileName = "GameData_", menuName = "Locadora/GameData", order = 1)]
public class GameData : ScriptableObject
{
    [Header("Identity")]
    public string id;
    public string title;

    [Header("Classification")]
    public PlatformType platform = PlatformType.PS2;
    public RankType rank = RankType.D;
    public GenreType genre = GenreType.Other;

    [Header("Economy")]
    public int purchasePrice = 50;
    public int rentalPrice = 3;

    [Header("Durability")]
    [Tooltip("Maximum durability per copy (0-100)")]
    public int maxDurability = 100;

    [Header("Visual")]
    public Sprite icon;

    [TextArea(2, 6)]
    public string description;
}

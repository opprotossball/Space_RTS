using System;
using UnityEngine;

/// Keeping all relevant information about a unit on a scriptable means we can gather and show
/// info on the menu screen, without instantiating the unit prefab.
public abstract class ScriptableUnitBase : ScriptableObject {
    public Faction Faction;

    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;

    // Used in game
    public UnitBase Prefab;
    
    // Used in menus
    public string Description;
    public Sprite MenuSprite;
}

/// Keeping base stats as a struct on the scriptable keeps it flexible and easily editable.
/// We can pass this struct to the spawned prefab unit and alter them depending on conditions.
[Serializable]
public struct Stats {
    public int Cost;
    public int Supply;
    public int Health;
    public int AttackPower;
    public int Range;
    public float ReloadTime;
    public float Speed;
}

[Serializable]
public enum Faction {
    Player0 = 0,
    Player1 = 1
}
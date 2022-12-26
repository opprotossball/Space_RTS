using System;
using UnityEngine;

/// Create a scriptable unit 
[CreateAssetMenu(fileName = "New Scriptable Example")]
public class ScriptableUnit : ScriptableUnitBase {
    public UnitType UnitType;
 
}

[Serializable]
public enum UnitType {
    FIGHTER = 0,
    DESTROYER = 1,
    DREDNOUGHT = 2
}


using System;
using UnityEngine;

/// Create a scriptable unit 
[CreateAssetMenu(fileName = "New Scriptable Example")]
public class ScriptableUnit : ScriptableUnitBase {
    public UnitType UnitType;
 
}

[Serializable]
public enum UnitType {
    Fighter = 0,
    Destroyer = 1,
    Drednought = 2
}


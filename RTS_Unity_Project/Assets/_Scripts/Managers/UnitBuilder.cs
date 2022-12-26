using UnityEngine;

/// An example of a scene-specific manager grabbing resources from the resource system
/// Scene-specific managers are things like grid managers, unit managers, environment managers etc
public class UnitBuilder : StaticInstance<UnitBuilder> {

    internal void SpawnUnit(UnitType t, Vector3 pos, Faction faction) {
        var scriptable = ResourceSystem.Instance.GetUnit(t);

        var spawned = Instantiate(scriptable.Prefab, pos, Quaternion.identity,transform);
        UnitBase spawnedUnit = spawned.GetComponent<UnitBase>();
        spawnedUnit.SetFaction(faction);
        
        // Apply possible modifications here such as potion boosts, team synergies, etc
        var stats = scriptable.BaseStats;
        spawnedUnit.SetStats(stats);
    }
}
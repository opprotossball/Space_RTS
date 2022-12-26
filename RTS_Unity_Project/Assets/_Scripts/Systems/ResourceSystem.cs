using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
public class ResourceSystem : StaticInstance<ResourceSystem> {
    public List<ScriptableUnit> Units { get; private set; }
    private Dictionary<UnitType, ScriptableUnit> _UnitDict;

    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
        Units = Resources.LoadAll<ScriptableUnit>("Ships").ToList();
        _UnitDict = Units.ToDictionary(r => r.UnitType, r => r);
    }

    public ScriptableUnit GetUnit(UnitType t) => _UnitDict[t];
}   
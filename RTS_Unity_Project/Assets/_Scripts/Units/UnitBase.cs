using System.Resources;
using UnityEngine;

/// This will share logic for any unit on the field. Could be friend or foe, controlled or not.
/// Things like taking damage, dying, animation triggers etc
public class UnitBase : MonoBehaviour {
    private Stats stats;
    public Faction Faction;
    private GameObject selectedGameObject;
    private Move move;

    protected void Awake() {
        selectedGameObject = transform.Find("Selected").gameObject;
        move = GetComponent<Move>();
        selectedGameObject.SetActive(false);
    }

    protected void Update() {
    }

    public virtual void SetFaction(Faction faction) => Faction = faction;
    
    public virtual void SetStats(Stats stats) {
        this.stats = stats;
    }

    public Stats GetStats() {
        return stats;
    }

    public void SetSelectedVisibility(bool visibility) {
        selectedGameObject.SetActive(visibility);
    }

    public virtual void TakeDamage(int dmg) {
        
    }

    public void MoveTo(Vector3 direction) {
        move.SetMoveTarget(direction);
    }

}
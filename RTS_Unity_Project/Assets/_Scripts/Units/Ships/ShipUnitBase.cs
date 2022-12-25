using UnityEngine;

public abstract class ShipUnitBase : UnitBase {
    private void Awake() { }

    private void OnDestroy() { }

    private void OnMouseDown() {
        // Eventually either deselect or ExecuteMove(). You could split ExecuteMove into multiple functions
        // like Move() / Attack() / Dance()

        Debug.Log("Unit clicked");
    }

}
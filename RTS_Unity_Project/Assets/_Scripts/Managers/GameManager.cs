using System;
using UnityEngine;

public class GameManager : StaticInstance<GameManager> {
    [SerializeField] UnitBuilder unitBuilder;
    private Vector3[] testFighterPositions = new Vector3[] {new Vector3(0, 0), new Vector3(-1.2f, -0.8f), new Vector3(.3f, 1f),
        new Vector3(0.8f, -2f), new Vector3(2.3f, -2f), new Vector3(-2, -3), new Vector3(-0.4f, 3.4f)
    };

    void Start() {
        //foreach (Vector3 pos in testFighterPositions) {
        //    unitBuilder.SpawnUnit(UnitType.FIGHTER, pos, Faction.Player0);
        //}
        RandomlySpawnFighters(Faction.Player0, 50);
    }
        

    private void HandleStarting() {
        // Do some start setup, could be environment, cinematics etc
    }

    private void RandomlySpawnFighters(Faction faction, int count) {
        System.Random random = new System.Random();
        for (int i = 0; i < count; i++) {
            float x = (float)random.NextDouble() * 10f - 5;
            float y = (float)random.NextDouble() * 10f - 5;
            Vector3 pos = new Vector3(x, y);
            unitBuilder.SpawnUnit(UnitType.FIGHTER, pos, Faction.Player0);
        }
    }   
}
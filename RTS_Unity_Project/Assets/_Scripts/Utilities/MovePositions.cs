using System.Collections.Generic;
using UnityEngine;

public class MovePositions
{
    [SerializeField] private static float startRadiusToSize = 1f;
    [SerializeField] private static float radiusSizeIncrementation = 1.6f;
    [SerializeField] private static float marginToSize = 2f;

    public static List<Vector3> GetPositionsArundTarget(Vector3 target, int unitCount, float spriteWidth, float spriteHeight) {
        List<Vector3> positions = new List<Vector3>();
        if (unitCount == 1) {
            positions.Add(target);
            return positions;
        }
        float spriteSize = Mathf.Max(spriteWidth, spriteHeight);
        spriteSize /= 2;
        float radius = startRadiusToSize * spriteSize;
        while (positions.Count < unitCount) {
            int countInRadius = (int)((2f * Mathf.PI * radius) / (marginToSize * spriteSize));
            for (int i = 0; i < countInRadius; i++) {
                float angle = i * (360f / countInRadius);
                Vector3 dir = ApplayRotation(new Vector3(1, 0), angle);
                Vector3 position = target + dir * radius;
                positions.Add(position);
            }
            radius += radiusSizeIncrementation * spriteSize;
        }
        return positions;
    }

    private static Vector3 ApplayRotation(Vector3 vec, float angle) {
        return Quaternion.Euler(0, 0, angle) * vec;
    }

}
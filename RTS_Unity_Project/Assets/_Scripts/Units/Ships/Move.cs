using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 moveTarget;
    private Rigidbody2D rb;
    [SerializeField] private UnitBase unit;
    [SerializeField] private float minDistance;

    public void SetMoveTarget(Vector3 target) {
        this.moveTarget = target;
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        moveTarget = transform.position;
    }

    private void FixedUpdate() {
        float moveSpeed = unit.GetStats().Speed;
        Vector3 moveDirection = (moveTarget - transform.position).normalized;
        if (Vector3.Distance(moveTarget, transform.position) < minDistance) {
            moveDirection = Vector3.zero;

        }
        rb.velocity = moveDirection * moveSpeed;
    }
        
}
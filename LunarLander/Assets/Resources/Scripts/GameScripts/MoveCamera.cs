using UnityEngine;

public class MoveCamera : MonoBehaviour {

    [SerializeField]
    Vector2 direction;

    [SerializeField]
    Rigidbody2D rb;

    private float force = 2500;

    void OnTriggerStay2D(Collider2D col)
    {
        rb.AddForce(direction * force);
    }

    
}

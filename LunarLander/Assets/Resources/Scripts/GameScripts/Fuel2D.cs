using UnityEngine;

public class Fuel2D : GameEntity {

    Rigidbody2D rb;

    [SerializeField]
    Transform centerPoint;

    Vector2 direction = Vector2.up;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {

        rb.AddRelativeForce(direction);

        if(centerPoint.position.y > transform.position.y)
        {
            direction = Vector2.up;
        }
        else
        {
            direction = Vector2.down;
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.GetComponent<Player>().HasCharge())
        {
            collision.GetComponent<Player>().SetFuelCharge();

            gameObject.SetActive(false);
        }
    }
}

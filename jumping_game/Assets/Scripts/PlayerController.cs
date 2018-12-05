using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 10f;

    private float movement = 0f;

    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        movement = Input.GetAxis("Horizontal");
	}

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement * movementSpeed;
        rb.velocity = velocity;
    }

    public void Lift(float speed, float time)
    {
        rb.gravityScale = 0;

        Vector2 velocity = rb.velocity;
        velocity.y = speed;
        rb.velocity = velocity;

        Invoke("LiftEnd", time);
    }

    private void LiftEnd()
    {
        rb.gravityScale = 1;
    }
}

using UnityEngine;

public class InstabilPlatform : Platform {

    [SerializeField]
    private int health = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GiveForce(collision);
        HealthCheck(collision);
    }

    private void HealthCheck(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            health--;
            if (health == 0)
            {
                Die();
            }
        }
    }
}

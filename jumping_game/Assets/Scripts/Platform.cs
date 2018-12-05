using UnityEngine;

public class Platform : MonoBehaviour {

    [SerializeField]
    private float jumpPower = 30;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GiveForce(collision);
    }

    private void Update()
    {
        DieCheck();
    }

    protected void DieCheck()
    {
        if (Camera.main.transform.position.y - Camera.main.orthographicSize > transform.position.y)
        {
            Die();
        }
    }

    protected void GiveForce(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpPower;
                rb.velocity = velocity;
            }
        }
    }

    protected void Die()
    {
        PlatformCreator platformCreator = PlatformCreator.GetInstance();
        platformCreator.CreatePlatform();
        Destroy(gameObject);
    }
}

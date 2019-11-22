using UnityEngine;

public class Platform : MonoBehaviour {

    [SerializeField]
    private float jumpPower = 30;

    private Rigidbody2D rigidbody;
    private Animator Animator;

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
                rigidbody = rb;

                //Stop it
                Vector2 velocity = rigidbody.velocity;
                velocity.y = 0;
                rigidbody.gravityScale = 0;
                rigidbody.velocity = velocity;


                //Add force after the jump
                Invoke("Go", 0.27f);
            }
            Animator animator = collision.collider.GetComponentInChildren<Animator>();
            if(animator != null)
            {
                animator.SetTrigger("Platform");
                animator.SetBool("LastState", true);
                animator.SetBool("InMove", true);

                Animator = animator;
            }
        }
    }

    private void Go()
    {
        Vector2 velocity = rigidbody.velocity;
        velocity.y = jumpPower;
        rigidbody.velocity = velocity;
        rigidbody.gravityScale = 5;

        Animator.SetBool("InMove", false);
    }

    protected void Die()
    {
        PlatformCreator platformCreator = PlatformCreator.GetInstance();
        platformCreator.CreatePlatform();
        Destroy(gameObject);
    }
}

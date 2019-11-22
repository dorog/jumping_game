using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private Image itemImage;

    private float movement = 0f;

    Rigidbody2D rb;

    private bool usingItem = false;

    public Animator animator;

    private bool isLeft = true;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if(!animator.GetBool("InMove"))
        {
            movement += Input.GetAxis("Horizontal");
        }
	}

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement * movementSpeed;
        rb.velocity = velocity;

        if(movement > 0 && isLeft)
        {
            animator.SetTrigger("Direction");
            isLeft = !isLeft;
        }
        else if(movement < 0 && !isLeft)
        {
            animator.SetTrigger("Direction");
            isLeft = !isLeft;
        }

        if (animator.GetBool("LastState") && rb.velocity.y < 0)
        {
            animator.SetBool("LastState", false);
            animator.SetTrigger("Fall");
        }

        movement = 0;
    }

    public void Lift(float speed, float time, Sprite itemIcon)
    {
        rb.gravityScale = 0;

        ActivateItem(itemIcon);

        Vector2 velocity = rb.velocity;
        velocity.y = speed;
        rb.velocity = velocity;

        usingItem = true;

        Invoke("LiftEnd", time);
    }

    private void LiftEnd()
    {
        rb.gravityScale = 1;

        usingItem = false;

        DeactivateItem();
    }

    private void ActivateItem(Sprite itemIcon)
    {
        itemImage.sprite = itemIcon;

        Color itemColor = itemImage.color;
        itemColor.a = 255f;
        itemImage.color = itemColor;
    }

    private void DeactivateItem()
    {
        itemImage.sprite = null;

        Color itemColor = itemImage.color;
        itemColor.a = 0f;
        itemImage.color = itemColor;
    }
}

using UnityEngine;

public class Lifter : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float time;
    [SerializeField]
    private Sprite itemIcon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        pc.Lift(speed, time, itemIcon);
        Destroy(gameObject);
    }
}

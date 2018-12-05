using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        pc.Lift(speed, time);
        Destroy(gameObject);
    }
}

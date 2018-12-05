using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLine : MonoBehaviour {

    [SerializeField]
    private float portPositionX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(portPositionX, collision.transform.position.y, collision.transform.position.z);
    }
}

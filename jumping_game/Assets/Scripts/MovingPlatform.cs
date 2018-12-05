using UnityEngine;

public class MovingPlatform : Platform {

    [SerializeField]
    private float speed;

    private float minX;
    private float direction;

    private void Start()
    {
        float mapX = 100f;

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        minX = horzExtent - mapX / 2f;

        direction = Random.Range(-1, 1) >= 0 ? 1 : -1;
    }

    void Update () {
        DieCheck();
        Move();
	}

    private void Move()
    {
        if(transform.position.x <= minX)
        {
            direction = 1;
        }
        else if (transform.position.x >= -minX)
        {
            direction = -1;
        }

        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);
    }
}

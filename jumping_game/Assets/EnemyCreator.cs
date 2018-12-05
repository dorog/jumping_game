using UnityEngine;

public class EnemyCreator : MonoBehaviour {

    [SerializeField]
    private int holeNumber;
    [SerializeField]
    private float holeMinRange;
    [SerializeField]
    private float holeMaxRange;
    [SerializeField]
    private float startPosition;
    [SerializeField]
    private GameObject blackHole;

    private float minX;
    private float lastY;

    private static EnemyCreator instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static EnemyCreator GetInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start () {
        float mapX = 100f;

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        minX = horzExtent - mapX / 2f;
        lastY = startPosition;
        for (int i = 0; i < holeNumber; i++)
        {
            CreateBlackHole();
        }
    }

    public void CreateBlackHole()
    {
        float x = Random.Range(-minX, minX);
        float y = lastY + Random.Range(holeMinRange, holeMaxRange);
        Instantiate(blackHole, new Vector3(x, y, 0), Quaternion.identity, transform);
        lastY = y;
    }
}

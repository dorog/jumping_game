using UnityEngine;

public class PlatformCreator : MonoBehaviour {

    public LevelData[] levels;

    [SerializeField]
    private GameObject basicPlatform;
    [SerializeField]
    private GameObject megaPlatform;
    [SerializeField]
    private GameObject movingPlatform;
    [SerializeField]
    private GameObject instabilPlatform;
    [SerializeField]
    private GameObject rocketPlatform;
    [SerializeField]
    private GameObject hatPlatform;

    [SerializeField]
    private float startHeight;
    [SerializeField]
    private int platformNumber;

    [SerializeField]
    private Transform cameraTransform;

    private float lastHeight;
    private float minX;

    private static PlatformCreator instance = null;

    private float minBP;
    private float maxBP;

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

    public static PlatformCreator GetInstance()
    {
        return instance;
    }

    void Start () {

        if (levels.Length < 1)
        {
            Debug.LogError("No level!");
            return;
        }

        float mapX = 100f;

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        minX = horzExtent - mapX / 2f;
        lastHeight = startHeight;

        minBP = levels[0].minBetweenPlatforms;
        maxBP = levels[0].maxBetweenPlatforms;

        for (int i=0; i< platformNumber; i++)
        {
            CreatePlatform();
        }
    }

    public void CreatePlatform()
    {
        float y = lastHeight + Random.Range(minBP, maxBP);
        float x = Random.Range(-minX, minX);
        GameObject platform = GetPlatformTpye();
        Instantiate(platform, new Vector3(x, y, 0), Quaternion.identity, transform);
        lastHeight = y;
    }

    private GameObject GetPlatformTpye()
    {
        LevelData actual = GetActualLevelData();

        minBP = actual.minBetweenPlatforms;
        maxBP = actual.maxBetweenPlatforms;

        float chance = Random.Range(0, 100);

        //BasicPlatform
        if(chance <= actual.basicPlatformChance)
        {
            return basicPlatform;
        }
        chance -= actual.basicPlatformChance;

        //MegaPlatform
        if (chance <= actual.megaPlatformChance)
        {
            return megaPlatform;
        }
        chance -= actual.megaPlatformChance;

        //MovingPlatform
        if (chance <=  actual.movingPlatformChance)
        {
            return movingPlatform;
        }
        chance -= actual.movingPlatformChance;

        //Instabil
        if(chance <= actual.instabilPlatformChance)
        {
            return instabilPlatform;
        }
        chance -= actual.instabilPlatformChance;

        //Rocket
        if (chance <= actual.rocketPlatformChance)
        {
            return rocketPlatform;
        }
        chance -= actual.rocketPlatformChance;

        //Hat
        if (chance <= actual.hatPlatformChance)
        {
            return hatPlatform;
        }
        chance -= actual.hatPlatformChance;

        return basicPlatform;
    }

    private LevelData GetActualLevelData()
    {
        LevelData actual = null;
        for(int i=0; i<levels.Length; i++)
        {
            if(levels[i].maxHeight >= cameraTransform.position.y)
            {
                actual = levels[i];
                break;
            }
        }
        if(actual == null)
        {
            actual = levels[levels.Length - 1];
        }
        return actual;
    }
}

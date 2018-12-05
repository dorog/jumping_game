using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "DoodleLevel")]
public class LevelData : ScriptableObject{

    public float minBetweenPlatforms;
    public float maxBetweenPlatforms;
    public float maxHeight;
    [Range(0, 100)]
    public int basicPlatformChance;
    [Range(0, 100)]
    public int megaPlatformChance;
    [Range(0, 100)]
    public int movingPlatformChance;
    [Range(0, 100)]
    public int instabilPlatformChance;
    [Range(0, 100)]
    public int rocketPlatformChance;
    [Range(0, 100)]
    public int hatPlatformChance;
}

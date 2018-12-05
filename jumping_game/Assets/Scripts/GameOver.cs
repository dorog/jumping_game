using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver {

    public static int score = 0;
    private static string menuName = "Menu";
    private static string resultScene = "ResultScene";

    public static void LoadResultScene()
    {
        SceneManager.LoadScene(resultScene);
    }

    public static void LoadMenuScene()
    {
        SceneManager.LoadScene(menuName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    [SerializeField]
    private string gameScene;
    [SerializeField]
    private GameObject scoreBoardView;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void ScoreBoard()
    {
        scoreBoardView.SetActive(true);
    }

    public void Menu()
    {
        scoreBoardView.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

using UnityEngine.UI;
using UnityEngine;

public class ScoreLoader : MonoBehaviour {

    [SerializeField]
    private Text scoreText;

	// Use this for initialization
	void Start () {
		if(GameOver.score != 0)
        {
            scoreText.text = "Last score: " + GameOver.score;
        }
        else
        {
            scoreText.gameObject.SetActive(false);
        }
	}
}

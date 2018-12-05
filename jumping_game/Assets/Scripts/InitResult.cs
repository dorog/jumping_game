using UnityEngine;
using UnityEngine.UI;

public class InitResult : MonoBehaviour {

    [SerializeField]
    private Text placeText;
    [SerializeField]
    private Text playerName;
    [SerializeField]
    private Text scoreText;

    public void Init(int place, Result data)
    {
        if(data.score < 0)
        {
            placeText.text = "";
            playerName.text = "";
            scoreText.text = "";
        }
        else
        {
            placeText.text = "" + place + ".";
            playerName.text = "" + data.name;
            scoreText.text = "" + data.score;
        }
    }
}

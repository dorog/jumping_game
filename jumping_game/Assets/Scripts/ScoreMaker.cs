using UnityEngine;
using UnityEngine.UI;

public class ScoreMaker : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Transform cameraTransform;
	
	void Update () {
        scoreText.text = "" + (int)cameraTransform.position.y;
    }
}

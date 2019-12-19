using UnityEngine;

public class CharacterEnd : MonoBehaviour {

    private static string tagName = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResultCheck(collision);
    }

    public static void ResultCheck(Collider2D collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            GameOver.score = (int)Camera.main.transform.position.y;
            if (GameOver.score > ReadScores.scoreBoard.scores[ReadScores.scoreBoard.scores.Length-1].score)
            {
                GameOver.LoadResultScene();
            }
            else
            {
                GameOver.LoadMenuScene();
            }
        }
    }
}

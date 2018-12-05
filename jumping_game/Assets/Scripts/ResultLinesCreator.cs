using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultLinesCreator : MonoBehaviour {

    [SerializeField]
    private GameObject resultLine;

	void Start () {
        int score;
        for(int i=0; i<ReadScores.scoreBoard.scores.Length; i++)
        {
            score = ReadScores.scoreBoard.scores[i].score;
            if (score >= 0)
            {
                GameObject go = Instantiate(resultLine, new Vector3(0, ReadScores.scoreBoard.scores[i].score, 0), Quaternion.identity, transform);
                ResultLine resultLineScript = go.GetComponent<ResultLine>();
                resultLineScript.Init(ReadScores.scoreBoard.scores[i].name);
            }
        }
    }
}

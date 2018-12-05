using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ReadScores : MonoBehaviour
{
    public static ScoreBoard scoreBoard = null;
    public static string deviceFileLocation = null;

    [SerializeField]
    private Transform scoreBoardView;
    [SerializeField]
    private GameObject ResultPrefab;

    void Start()
    {
        deviceFileLocation = Application.persistentDataPath + "/scores.bat";
        ReadAllScores();
        CreateScoreBoard();
    }

    private void ReadAllScores()
    {
        if(scoreBoard != null)
        {
            return;
        }
        if (File.Exists(deviceFileLocation))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceFileLocation, FileMode.Open);
            ScoreBoard psData = (ScoreBoard)bf.Deserialize(file);
            file.Close();

            scoreBoard = psData;
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceFileLocation, FileMode.Create);
            ScoreBoard data = new ScoreBoard();

            data.scores = new Result[10];

            for (int i = 0; i < data.scores.Length; i++)
            {
                data.scores[i] = new Result();
                data.scores[i].score = -1;
            }

            bf.Serialize(file, data);
            file.Close();

            scoreBoard = data;
        }
    }

    public void CreateScoreBoard()
    {
        for(int i=0; i<scoreBoard.scores.Length; i++)
        {
            GameObject resultPrefab = Instantiate(ResultPrefab, scoreBoardView);
            InitResult initResult = resultPrefab.GetComponent<InitResult>();
            initResult.Init(i+1, scoreBoard.scores[i]);
        }
    }
}

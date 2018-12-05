using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveResult : MonoBehaviour {

    [SerializeField]
    private Text playerName;
    [SerializeField]
    private string menuName;

    public void Save()
    {
        Result newResult = new Result();
        newResult.name = playerName.text;
        newResult.score = GameOver.score;

        int place = SearchPlace(newResult.score);
        Insert(place, newResult);
        SaveData();
        SceneManager.LoadScene(menuName);
    }

    private int SearchPlace(int score)
    {
        int place = 0;
        for(int i=8; i>=0; i--)
        {
            if (ReadScores.scoreBoard.scores[i].score > score)
            {
                place = i+1;
                break;
            }
        }
        return place;
    }

    private void Insert(int place, Result newResult)
    {
        for(int i=8; i>=place; i--)
        {
            ReadScores.scoreBoard.scores[i+1] = ReadScores.scoreBoard.scores[i];
        }

        ReadScores.scoreBoard.scores[place] = newResult;
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileForSave = File.Create(ReadScores.deviceFileLocation);
        bf.Serialize(fileForSave, ReadScores.scoreBoard);
        fileForSave.Close();
    }
}

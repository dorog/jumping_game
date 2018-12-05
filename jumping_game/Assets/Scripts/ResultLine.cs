using UnityEngine;
using UnityEngine.UI;

public class ResultLine : MonoBehaviour {

    [SerializeField]
    private Text lineName;
    
    public void Init(string name)
    {
        lineName.text = name;
    }
}

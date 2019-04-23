using filewriter;
using System;
using UnityEngine;
using UnityEngine.UI;

public class addcurrentgamedata : MonoBehaviour
{

    public Text email;
    public Text score;
    public Text date;


    private void Start()
    {
        ScoreNameToFile DataHandler = new ScoreNameToFile();

        email.text =  DataHandler.GetUserName();
        score.text = DataHandler.GetScore();
        date.text = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");

    }


}

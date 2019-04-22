using filewriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addcurrentgamedata : MonoBehaviour
{

    public Text email;
    public Text score;


    private void Start()
    {
        ScoreNameToFile DataHandler = new ScoreNameToFile();

        email.text =  DataHandler.GetUserName();
        score.text = DataHandler.GetScore();

    }


}

using filewriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Game : MonoBehaviour
{
   public void ExitGame()
    {
        //removes data files from user comptuer
        ScoreNameToFile DataRecorder = new ScoreNameToFile();
        DataRecorder.DeletefileScore();
        DataRecorder.DeleteUserFile();

        //quits game
        Application.Quit();
    }
}

using filewriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromInputScreen : MonoBehaviour
{
         
    public void ExitWithoutAction()
    {
        //removes data files from user comptuer
        ScoreNameToFile DataRecorder = new ScoreNameToFile();
        DataRecorder.DeletefileScore();
        DataRecorder.DeleteUserFile();

        //quits program
        Application.Quit();
        
    }
}

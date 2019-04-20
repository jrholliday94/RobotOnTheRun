using filewriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubmitFromNameInput : MonoBehaviour
{
    //link to Text inputbox
    public Text TextboxInput;
    

     public void SubmitName()
    {
        ScoreNameToFile DataHandler = new ScoreNameToFile();

        //stores userinput to file
        DataHandler.UpdateUser(TextboxInput.text.ToString());

        //loads main menu
        SceneManager.LoadScene("IntroLevel");

    }
    
   

}

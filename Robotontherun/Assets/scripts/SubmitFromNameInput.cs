using filewriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubmitFromNameInput : MonoBehaviour
{
    //link to Text inputbox
    public Text TextboxInput;
        
    //holds remove data
    private string data;

    //link to error text box
    public Text ErrorMessage;

    void Start()
    {
        StartCoroutine(GetBoard());
    }

    IEnumerator GetBoard()
    {
        UnityWebRequest result = UnityWebRequest.Get("http://cis174-bfrederickson-website.azurewebsites.net/API/v1/people/get");
        yield return result.SendWebRequest();

         data = result.downloadHandler.text;
    }

    public void SubmitName()
    {
        ScoreNameToFile DataHandler = new ScoreNameToFile();

        var inputeddata = TextboxInput.text.ToString();

        if(data.Contains(inputeddata) && inputeddata.Contains("@"))
        {
            //stores userinput to file
            DataHandler.UpdateUser(TextboxInput.text.ToString());
                        
            //loads main menu
            SceneManager.LoadScene("IntroLevel");
            
        }
        else
        {
            //Show error message
            ErrorMessage.text = "E-mail not found! Please register at: http://cis174-bfrederickson-website.azurewebsites.net/";
        }
    }
}

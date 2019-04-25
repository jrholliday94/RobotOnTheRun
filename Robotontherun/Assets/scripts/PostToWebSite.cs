using filewriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostToWebSite : MonoBehaviour
{

    //Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(Upload());
        
    }

    IEnumerator Upload()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("email=Test2@Test.com&newHighscore=1100"));

        WWWForm form = new WWWForm();


        ScoreNameToFile DataHandler = new ScoreNameToFile();

        string email = DataHandler.GetUserName();
        string score = DataHandler.GetScore();

        string url = "http://cis174-bfrederickson-website.azurewebsites.net/API/v1/highscores/?email=" + email + "&newHighscore=" + score;

        UnityWebRequest www = UnityWebRequest.Post(url, "");
        Debug.Log(www.uri + www.url);
        yield return www.SendWebRequest();
        
    }

}

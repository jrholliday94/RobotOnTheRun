using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostToWebSite : MonoBehaviour
{

    public Text statusText;

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

        Dictionary<string, string> headers = form.headers;
        headers["email"] = "Test2@Test.com";
        headers["newHighscore"] = "2500";
               
        WWW request = new WWW("http://cis174-bfrederickson-website.azurewebsites.net/API/v1/highscores", null, headers);

        UnityWebRequest www = UnityWebRequest.Post("http://cis174-bfrederickson-website.azurewebsites.net/API/v1/highscores/set?email=Default@email.com&newHighscore=2500", form);
        Debug.Log(www.uri + www.url);
        yield return request;

        Debug.Log("Method Run");

        Debug.Log(request.text);

        if (request.text.Contains("error"))
        {
            statusText.text += "Error uploading";

        } else if(request.text.Contains("Nothing was created"))
        {
            statusText.text += "No highscore created";

        } else if(request.text.Contains("Highscore was created"))
        {
            statusText.text += "New highscore!";
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostToWebSite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(Upload());

        


    }

    IEnumerator Upload()
    {
        //  List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        //  formData.Add(new MultipartFormDataSection("email=Test2@Test.com&newHighscore=1100"));

        WWWForm form = new WWWForm();
        form.AddField("email", "Test2@Test.com");
        form.AddField("newHighscore", "2500");

         UnityWebRequest www = UnityWebRequest.Post("http://cis174-bfrederickson-website.azurewebsites.net/API/v1/highscores/set?email=Default@email.com&newHighscore=2500", form);
        Debug.Log(www.uri + www.url);
        yield return www.SendWebRequest();

            

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            
           
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        
    }

}

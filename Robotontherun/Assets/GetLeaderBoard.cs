using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class GetLeaderBoard : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetBoard());
    }

    IEnumerator GetBoard()
    {
        UnityWebRequest result = UnityWebRequest.Get("http://cis174-bfrederickson-website.azurewebsites.net/API/v1/highscores/get");
        yield return result.SendWebRequest();


        var data = result.downloadHandler.text;

        
        for(int x=0; x < data.Count(); x++)
        {
            var insidedata = data[x];
            Debug.Log(data[x]);

        }

        if (result.isNetworkError || result.isHttpError)
        {
            Debug.Log(result.error);
        }
        else
        {
            
            Debug.Log(result.downloadHandler.text);
            
                  
        }
    }
}

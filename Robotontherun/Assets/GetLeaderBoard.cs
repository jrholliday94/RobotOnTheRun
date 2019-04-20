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
        UnityWebRequest result = UnityWebRequest.Get("http://cis174-imtibe-web.azurewebsites.net/api/v1/highscore");
        yield return result.SendWebRequest();

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

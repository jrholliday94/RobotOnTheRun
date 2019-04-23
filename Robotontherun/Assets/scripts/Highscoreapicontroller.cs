using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Highscoreapicontroller : MonoBehaviour
{
    public GameObject RowPrefab;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetBoard());
    }

    IEnumerator GetBoard()
    {
        var gethighscores = UnityWebRequest.Get("http://cis174-bfrederickson-website.azurewebsites.net/API/v1/highscores/get");
        yield return gethighscores.SendWebRequest();

        if(gethighscores.isNetworkError || gethighscores.isHttpError )
        {
            Debug.Log(gethighscores.error);
        }
        else
        {
            //Debug.Log(gethighscores.responseCode);
            var JsonResult = gethighscores.downloadHandler.text;
            
            var highScore = JsonConvert.DeserializeObject<List<HighScoreViewModel>>(JsonResult);

            int i = 1;
            foreach (var score in highScore)
            {

                var row = GameObject.Instantiate(RowPrefab, Panel.transform);
                row.GetComponent<RowController>().SetAllFields(

                    i + ". " + score.Email,
                    score.stringscore,
                    score.stringdatetime);
                    i++;
            }
        }

    }
}

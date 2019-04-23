using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public int nextSceneNumber;
    public PostToWebSite postScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var currentscene = SceneManager.GetActiveScene();
        string SceneName = currentscene.name;


        if (SceneName == "Level 4")
        {
            Debug.Log("level 4");

            PlayerController data = (PlayerController)collision.gameObject.GetComponent("PlayerController");
            data.RecordScoreOnExit();

            postScore.Start();

            SceneManager.LoadScene("LeaderBoard");
        }
        else
        {
            PlayerController data = (PlayerController)collision.gameObject.GetComponent("PlayerController");
            data.RecordScoreOnExit();
            SceneManager.LoadScene(nextSceneNumber);

        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public int nextSceneNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var currentscene = SceneManager.GetActiveScene();
       string SceneName = currentscene.name;
        if (SceneName == "Level 4")
        {
            PlayerController data = (PlayerController)collision.gameObject.GetComponent("PlayerController");
            data.RecordScoreOnExit();
            //add post commands here
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

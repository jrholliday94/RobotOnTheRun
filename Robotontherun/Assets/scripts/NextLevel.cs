using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public int nextSceneNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController data = (PlayerController) collision.gameObject.GetComponent("PlayerController");
        data.RecordScoreOnExit();
       
        SceneManager.LoadScene(nextSceneNumber);
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public int nextSceneNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextSceneNumber);
    }

}

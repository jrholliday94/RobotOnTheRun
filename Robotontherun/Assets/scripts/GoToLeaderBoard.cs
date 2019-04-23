using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLeaderBoard : MonoBehaviour
{
   //script to go to leader board scene
   public void ToLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");       
    }
}

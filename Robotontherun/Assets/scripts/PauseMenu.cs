using filewriter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject LeaderboardUI;

    private bool paused = false;
    private bool leaderBoardUp = false;

    void Start()
    {
        PauseUI.SetActive(false);
        LeaderboardUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause") && leaderBoardUp == false)
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);

            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);

            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        //removes data files from user comptuer
        ScoreNameToFile DataRecorder = new ScoreNameToFile();
        DataRecorder.DeletefileScore();
        DataRecorder.DeleteUserFile();

        //quits game
        Application.Quit();
    }

    public void ShowLeaderUI()
    {
        PauseUI.SetActive(false);
        leaderBoardUp = true;
        LeaderboardUI.SetActive(true);
    }

    public void HideLeaderUI()
    {
        PauseUI.SetActive(true);
        leaderBoardUp = false;
        LeaderboardUI.SetActive(false);
    }
}

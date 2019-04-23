using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowController : MonoBehaviour
{
    public Text HighScoreID;
    public Text PersonId;
    public Text Email;
    public Text Score;
    public Text DateAtained;

    public void SetAllFields(string highscoreid, string personid, string email, string score, string dateatainted)
    {
        HighScoreID.text = highscoreid;
        PersonId.text = personid;
        Email.text = email;
        Score.text = score;
        DateAtained.text = dateatainted;
    }

}

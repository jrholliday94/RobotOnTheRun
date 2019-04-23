using UnityEngine;
using UnityEngine.UI;

public class RowController : MonoBehaviour
{

    public Text Email;
    public Text Score;
    public Text DateAttained;

    public void SetAllFields(string email, string score, string dateAttained)
    {
        Email.text = email;
        Score.text = score;
        DateAttained.text = dateAttained;
    }

}

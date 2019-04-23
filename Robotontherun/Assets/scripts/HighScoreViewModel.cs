using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreViewModel : MonoBehaviour
{
    public Guid HighScoreId { get; set; }
    public string stringhighscoreid => HighScoreId.ToString();
    public Guid PersonId { get; set; }
    public string stringpersonid => PersonId.ToString();
    public string Email { get; set; }
    public decimal Score { get; set; }
    public string stringscore => Score.ToString();
    public DateTime DateTime { get; set; }
    public string stringdatetime => DateTime.ToString();
        
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateNewGame : MonoBehaviour
{
   public void StartNewGame()
    {
        SceneManager.LoadScene(2);
    }
}

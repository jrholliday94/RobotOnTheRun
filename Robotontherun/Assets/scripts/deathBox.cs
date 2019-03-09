using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathBox : MonoBehaviour
{
    private GameObject thePlayer;
    private PlayerController playerScript;

    void Start()
    {
        thePlayer = GameObject.Find("Player");
        playerScript = thePlayer.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerScript.Die();
    }
}

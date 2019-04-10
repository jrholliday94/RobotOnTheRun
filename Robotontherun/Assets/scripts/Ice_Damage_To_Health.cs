using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Damage_To_Health : MonoBehaviour
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
        if (!playerScript.damagedRecently && collision.gameObject.name == "Player")
        {
            
            playerScript.TakeDamage();
        }
    }
}

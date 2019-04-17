using System;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!playerScript.damagedRecently && collision.gameObject.name == "Player")
        {

            playerScript.TakeDamage();
        }
    }
}

using UnityEngine;

public class Upright_Ice_Kill : MonoBehaviour
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

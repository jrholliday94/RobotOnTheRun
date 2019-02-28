using UnityEngine;

public class GetHurt : MonoBehaviour
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

        if (!playerScript.damagedRecently)
        {
            playerScript.TakeDamage();
        }
    }
}

using UnityEngine;

public class FireballHurt : MonoBehaviour
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
        if (!playerScript.damagedRecently)
        {
            playerScript.TakeDamage();
        }
    }
}

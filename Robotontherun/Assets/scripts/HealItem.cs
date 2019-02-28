using UnityEngine;

public class HealItem : MonoBehaviour
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
        if (playerScript.currentHealth < playerScript.maxHealth)
        {
            playerScript.TakeHeal();
            Destroy(this.gameObject);
        }
    }
}

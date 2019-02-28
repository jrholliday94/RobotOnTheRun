using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public int value = 100; // Value to add to score when collected

    private GameObject thePlayer;
    private PlayerController playerScript;

    void Start()
    {
        thePlayer = GameObject.Find("Player");
        playerScript = thePlayer.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript.AddScore(value);
        Destroy(this.gameObject);
    }
}

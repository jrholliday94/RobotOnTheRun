using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HealthSprites;
    public Image HeartUI;
    private PlayerController Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Player.currentHealth < 0)
        {
            Player.currentHealth = 0;
        }

        HeartUI.sprite = HealthSprites[Player.currentHealth];
    }
}

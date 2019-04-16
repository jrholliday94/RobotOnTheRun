using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class falling_ice : MonoBehaviour
{

    public GameObject FallingIce;
    private int RandomNumber;
    private System.Random random;
    public int HighRange;
    public float LiveTime;

    private void Start()
    {
        random = new System.Random();
        
    }

         
    public void Update()
    {
        
        int randomNumber = random.Next(1, HighRange);

        if (randomNumber == 1)
        {
            GameObject item;
            item = Instantiate(FallingIce, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);

            Destroy(item, LiveTime);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_platform : MonoBehaviour
{
    public float Distance;
    public float Speed;
    private double XPositionOffset;
    private float InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        XPositionOffset = 0;
        InitialPosition = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        XPositionOffset = (Math.Sin(Time.time * Speed) * Distance) +  InitialPosition;

        gameObject.transform.position = new Vector2( (float) XPositionOffset, gameObject.transform.position.y);

                
    }
}

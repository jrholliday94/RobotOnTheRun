using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisibleOnStart : MonoBehaviour
{
    
    void Awake()
    {
        gameObject.SetActive(false);    
    }

    
}

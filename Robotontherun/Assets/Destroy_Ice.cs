using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Ice : MonoBehaviour
{

    public float TimeUntilDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeUntilDestroy);    
    }

    
}

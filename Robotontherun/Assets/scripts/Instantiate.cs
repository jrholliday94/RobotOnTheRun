using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public Transform myPrefab;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(myPrefab, new Vector3(i * 1.0F, 0, 0), Quaternion.identity);
        }
    }

}

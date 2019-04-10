using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Ice_Script : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void Update()
    {
        if (gameObject.transform.position.y < -10.0f)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }
}

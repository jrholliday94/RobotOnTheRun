using UnityEngine;

public class FireballEnemy : MonoBehaviour
{

    public float speed = 10;




    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * speed);
    }
}

using UnityEngine;

public class FireballEnemy : MonoBehaviour
{

    public float rotateSpeed = 10;
    public float xSpeed = 1;
    public float ySpeed = 1;
    public float maxPosX;
    public float minPosX;
    public float maxPosY;
    public float minPosY;

    public bool goingUp = true;
    public bool goingRight = true;

    private float maxY;
    private float minY;
    private float maxX;
    private float minX;

    private void Start()
    {
        // Get relative positions
        maxY = transform.position.y + maxPosY;
        minY = transform.position.y + minPosY;

        maxX = transform.position.x + maxPosX;
        minX = transform.position.x + minPosX;
    }

    void Update()
    {
        // Rotate every frame
        transform.Rotate(Vector3.back * rotateSpeed);

        // Vertical movement
        if(transform.position.y < maxY && goingUp == true)
        {
            transform.Translate(0, Time.deltaTime * xSpeed, 0, Space.World);
        }
        else
        {
            transform.Translate(0, Time.deltaTime * -1 * xSpeed, 0, Space.World);
            goingUp = false;
            if (transform.position.y < minY && goingUp == false)
            {
                goingUp = true;
            }
        }

        // Horizontal movement
        if (transform.position.x < maxX && goingRight == true)
        {
            transform.Translate(Time.deltaTime * ySpeed, 0, 0, Space.World);
        }
        else
        {
            transform.Translate(Time.deltaTime * -1 * ySpeed, 0, 0, Space.World);
            goingRight = false;

            if (transform.position.x < minX && goingRight == false)
            {
                goingRight = true;
            }
        }
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Public variables.
    public GameObject player;

    // Private variables.
    private Vector3 offset;

    // Starts with the game.
    void Start()
    {
        // Moves the camera based on the players current position.
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Changes the position of the camera based on the player everytime LateUpdate() is called.
        transform.position = player.transform.position + offset;
    }
}

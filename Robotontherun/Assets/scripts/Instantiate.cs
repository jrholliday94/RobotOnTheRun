using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public Transform player;
    public Transform ground;
    public Transform heart;
    public Transform coin;
    public Transform bush;

    void Start()
    {

        Instantiate(player, new Vector3(-1, 2, 0), Quaternion.identity);
        Instantiate(ground, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(heart, new Vector3(1.5f, 2.5f, 0), Quaternion.identity);
        Instantiate(coin, new Vector3(.75f, 2.5f, 0), Quaternion.identity);
        Instantiate(bush, new Vector3(2, 1.75f, 0), Quaternion.identity);

    }

}

using UnityEngine;

public class BridgeFall : MonoBehaviour
{

    private bool falling = false;
    private Vector2 goDown;

    void Update()
    {
        
        if(falling == true)
        {
            goDown.Set(transform.position.x, -100);
            this.transform.position = Vector2.MoveTowards(transform.position, goDown, .1f);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        falling = true;

    }

}

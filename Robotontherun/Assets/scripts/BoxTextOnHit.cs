using UnityEngine;
using UnityEngine.UI;

public class BoxTextOnHit : MonoBehaviour
{

    public string showText; // Text to show on collision
    public float textTime;    // Time text is shown
    public Text text;       // Text object
     
    private bool textShowing; // Text is currently shown or not
    private float timer;          // Count down from textTime until timer = 0 to remove text


    void Start()
    {
        textShowing = false;
    }


    void Update()
    {
        
        if(textShowing == true)
        {
            if(timer > 1)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                text.text = "";
                textShowing = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.text = showText;
        textShowing = true;
        timer = textTime;
    }
}

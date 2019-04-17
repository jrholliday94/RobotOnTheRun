using UnityEngine;

public class LightTorch : MonoBehaviour
{

    private SpriteRenderer mySpriteRenderer;
    private bool lit = false;
    private bool litLeft = false;
    private int framesUntilSwitch;
    private System.Random random;

    public Sprite litTorchLeft;
    public Sprite litTorchRight;
    public int minFramesUntilSwitch;
    public int maxFramesUntilSwitch;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        random = new System.Random();
    }

    private void Update()
    {
        framesUntilSwitch--;
        if (lit == true)
        {
            if(framesUntilSwitch <= 0)
            {
                if (litLeft == false)
                {
                    litLeft = true;
                    mySpriteRenderer.sprite = litTorchLeft;
                }
                else if (litLeft == true)
                {
                    litLeft = false;
                    mySpriteRenderer.sprite = litTorchRight;
                }
            }
        }

        if (framesUntilSwitch <= 0)
        {
            framesUntilSwitch = random.Next(minFramesUntilSwitch, maxFramesUntilSwitch);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lit = true;
        framesUntilSwitch = random.Next(minFramesUntilSwitch, maxFramesUntilSwitch);
        mySpriteRenderer.sprite = litTorchLeft;
    }
}


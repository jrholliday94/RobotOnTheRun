// Taken from Unity 2d tutorial: https://unity3d.com/learn/tutorials/topics/2d-game-creation/horizontal-movement?playlist=17093
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using filewriter;

public class PlayerController : Physics
{
    // Movement properties
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    // Added for double jump
    private bool SecondJumpAvailable = true;

    // References
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Text scoreText;
    public Text timerText;

    //added for score tracking
    public ScoreNameToFile DataRecorder;

    // Take damage properties
    public bool damagedRecently = false; // Must be public to allow GetHurt script to take advantage

    private readonly float immunityTime = 0.5f;  // seconds of immunity after taking damage
    private float timeCounter;
    

    // Stats
    public int currentHealth;
    public int maxHealth = 4;
    public int damageScore = 25; // Amount of score to take on player damage
    public float levelTime = 120;


    private int score;
    
    //Get Scene name properties for double jump.
    Scene CurrentScene;
    string SceneName;

    
    

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        // added for score tracking
        DataRecorder = new ScoreNameToFile();

        // Start the game with max health.
        currentHealth = maxHealth;

        // Get information for double jump.
        CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;

        //Setting scoreboard
        //adjusted by to set score on new Scene

        //added to fix bug that always adds 200 points to score when you die on level 3 and 4
        //if (SceneName == "Level 3" || SceneName == "Level 4")
       // {
        //    score = score - 200;
        //   Debug.Log("Ran Scorefix");
       // }

        if (SceneName == "Level 1")
         {
                score = 0;
                Debug.Log("Set score property to 0");
         }
        else
         {
                int ReceivedScore;
                int.TryParse(DataRecorder.GetScore(), out ReceivedScore);
                score = ReceivedScore;

           
            Debug.Log("Ran set property with no level 1 ReceivedScore is" + ReceivedScore.ToString());
                Debug.Log("score property is :" + score.ToString());
         }
            Debug.Log("Score sent to screen is " + score.ToString());
            scoreText.text = "Score: " + score.ToString();
        Debug.Log("Start method is run");
              

    }

    // Allows the player to 'die'.
    public void Die()
    {
        Debug.Log("Die method is run");
        
        
        //record current score to data file
      //  DataRecorder.UpdateScore(score.ToString());
        // If you die restart the game.
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        //added to correct random loss of 200 points of level 3 and level 4 
        if(levelTime > 118)
        {
            if (SceneName == "Level 3" || SceneName == "Level 4")
            {
                int ReceivedScore;
                int.TryParse(DataRecorder.GetScore(), out ReceivedScore);
                score = ReceivedScore;
                scoreText.text = "Score: " + score.ToString();
            }
        }

        ComputeVelocity();

        // Decrease immunity timer when damaged
        if (timeCounter > 0 && damagedRecently == true)
        {
            timeCounter -= Time.deltaTime;
        }
        else if (timeCounter <= 0)
        {
            damagedRecently = false;
            timeCounter = immunityTime;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }

        // When level time runs out, restart level
        if(levelTime > 0)
        {
            levelTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.RoundToInt(levelTime).ToString();
        }
        else
        {
            Die();
        }
        /*
        // If player falls off map, restart level
        if(transform.position.y < -15)
        {
            Die();
        }
        */
        Debug.Log(score.ToString());
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            SecondJumpAvailable = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        // Allows the player to double jump on specific scenes.
        if (SceneName == "Level 3" || SceneName == "Level 4")
        {
            if (Input.GetButtonDown("Jump") && !grounded && SecondJumpAvailable == true)
            {
                velocity.y = jumpTakeOffSpeed;
                SecondJumpAvailable = false;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * 0.5f;
                }
            }
        }

        bool flipSprite = false;

        if (spriteRenderer.flipX == false && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
        {
            flipSprite = true;
        }
        else if (spriteRenderer.flipX == true && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
        {
            flipSprite = true;
        }

        // Flips sprite if needed
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    public void TakeDamage()
    {
        if (!damagedRecently)
        {
            currentHealth--;
            damagedRecently = true;
            score -= damageScore;
            scoreText.text = "Score: " + score.ToString();
            Debug.Log("Take damage is run");
        }
    }

    public void TakeHeal()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth++;
        }
        Debug.Log("Take Heal is run");
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Add score is run");
    }

    public void RecordScoreOnExit()
    {
        DataRecorder.UpdateScore(score.ToString());
        Debug.Log("Ran RecordScoreonExit() method with score value of" + score.ToString());
    }
}

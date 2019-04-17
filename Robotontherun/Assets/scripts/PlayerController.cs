// Taken from Unity 2d tutorial: https://unity3d.com/learn/tutorials/topics/2d-game-creation/horizontal-movement?playlist=17093
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        // Start the game with max health.
        currentHealth = maxHealth;

        // Get information for double jump.
        CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;

        //Setting scoreboard
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    // Allows the player to 'die'.
    public void Die()
    {
        // If you die restart the game.
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
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
        }
    }

    public void TakeHeal()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth++;
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score.ToString();
    }
}

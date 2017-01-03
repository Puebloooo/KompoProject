using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool stoppedJumping;
    private float jumpTimeCounter;
    private float originalMovementSpeed;
    private float originalSpeedIncreaseMilestone;
    private float originalSpeedMilestoneCount;
    private float speedMilestoneCount;
    private Animator playerAnimator;
    //private Collider2D playerCollider; 
    private Rigidbody2D playerRigidbody;
    
    public bool grounded;
    public float groundCheckRadius;
    public float jumpTime;
    public float jumpForce;
    public float movementSpeed;
    public float speedIncreaseMilestone;
    public float movementSpeedMultiplier;
    public LayerMask layerMask;
    public GameManager gameManager;
    public Transform groundCheck;

	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<Collider2D>(); // used for older version of ground detection
        playerAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;

        originalMovementSpeed = movementSpeed;
        originalSpeedMilestoneCount = speedMilestoneCount;
        originalSpeedIncreaseMilestone = speedIncreaseMilestone;
        stoppedJumping = true;
    }
	
	void Update () {

        //grounded = Physics2D.IsTouchingLayers(playerCollider,layerMask); 

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerMask); // revise name of layermask 

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * movementSpeedMultiplier;
            movementSpeed = movementSpeed * movementSpeedMultiplier;
        }

        playerRigidbody.velocity = new Vector2(movementSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            if (grounded)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
            }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !stoppedJumping)
            if (jumpTimeCounter > 0)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
        if (grounded)
            jumpTimeCounter = jumpTime;
        
        playerAnimator.SetFloat("Speed", playerRigidbody.velocity.x);
        playerAnimator.SetBool("Grounded", grounded);
	}
    void OnCollisionEnter2D (Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Killbox")
        {
            gameManager.RestartGame();
            movementSpeed = originalMovementSpeed;
            speedMilestoneCount = originalSpeedMilestoneCount;
            speedIncreaseMilestone = originalSpeedIncreaseMilestone;

        }
    }
}

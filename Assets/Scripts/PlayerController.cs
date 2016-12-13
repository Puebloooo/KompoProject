using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float jumpTimeCounter;
    private Animator playerAnimator;
    private Collider2D playerCollider;
    private Rigidbody2D playerRigidbody;
    
    public bool grounded;
    public float movementSpeed;
    public float jumpTime;
    public float jumpForce;
    public LayerMask layerMask;
    
	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.IsTouchingLayers(playerCollider,layerMask);

        playerRigidbody.velocity = new Vector2(movementSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            if(grounded)
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x , jumpForce);
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
            if (jumpTimeCounter > 0)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            jumpTimeCounter = 0;
        if (grounded)
            jumpTimeCounter = jumpTime;
        playerAnimator.SetFloat("Speed", playerRigidbody.velocity.x);
        playerAnimator.SetBool("Grounded", grounded);
	}
}

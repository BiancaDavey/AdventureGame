using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5f;

    public Rigidbody2D rigidBody;  
    public Animator animator;  // adding animation.

    // Variable stores an x and y
    Vector2 playerMovement; 

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        // Update is called once per frame
        // BUT don't use Update for physics: framerate can constantly change.
        // Instead, use Fixed Update.
        // BUT use to handle input.

        // Variable storing x and y value, taken by GetAxisRaw returns value -1 to 1
        playerMovement.x = Input.GetAxisRaw("Horizontal");  // right 1, left -1
        playerMovement.y = Input.GetAxisRaw("Vertical");  
        // Removing diagonal movement.
        if (playerMovement.x != 0) playerMovement.y = 0;

        // Adding animation
        animator.SetFloat("Horizontal", playerMovement.x);
        animator.SetFloat("Vertical", playerMovement.y);
        animator.SetFloat("MovementSpeed", playerMovement.sqrMagnitude);
    }

    // Executed on a fixed timer, not stuck to timer like Update. 50x/second.
    // SO use to handle movement.
    void FixedUpdate()
    {
        // Time.fixedDeltaTime fixed time from when last called.
        rigidBody.MovePosition(rigidBody.position + playerMovement * movementSpeed * Time.fixedDeltaTime);

    }
}





/* TUTORIAL TWO

* Brackeys - this one works

    public float movementSpeed = 5f;

    public Rigidbody2D rigidBody;  

    // Variable stores an x and y
    Vector2 playerMovement; 

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        // Update is called once per frame
        // BUT don't use Update for physics: framerate can constantly change.
        // Instead, use Fixed Update.
        // BUT use to handle input.

        // Variable storing x and y value, taken by GetAxisRaw returns value -1 to 1
        playerMovement.x = Input.GetAxisRaw("Horizontal");  // right 1, left -1
        playerMovement.y = Input.GetAxisRaw("Vertical");  
    }

    // Executed ona  fixed timer, not stuck to timer like Update. 50x/second.
    // SO use to handle movement.
    void FixedUpdate()
    {
        // Time.fixedDeltaTime fixed time from when last called.
        rigidBody.MovePosition(rigidBody.position + playerMovement * movementSpeed * Time.fixedDeltaTime);

    }

*/



/* TUTORIAL ONE

* Can move left or right, but then player freezes and is shaking, game won't stop.


    public float movementSpeed;
    private bool playerMoving;
    private Vector2 input;

    private void Update() 
    {
        if (!playerMoving)
        {
            // Input always 1 or -1, ie right key = 1, left = -1
            input.x = Input.GetAxisRaw("Horizontal");  
            input.y = Input.GetAxisRaw("Vertical");

            // Optional: allow only for left/right movement, no diagonal movement.
            //if (input.x != 0) input.y = 0;
        
        }

        if (input != Vector2.zero) 
        {
            var targetPosition = transform.position;
            targetPosition.x += input.x;
            targetPosition.y += input.y;

            StartCoroutine(Move(targetPosition));
        }
    }

    // Returns IEnumerator assets; function to move player from current to target position over time
    IEnumerator Move(Vector3 targetPosition)
    {
        playerMoving = true;

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // Checks for substantial difference before moving
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            // Stops function, resumes at next Update function
            yield return null;
        }
        
        // Sets player's current position to the target position
        transform.position = targetPosition;

        playerMoving = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

*/





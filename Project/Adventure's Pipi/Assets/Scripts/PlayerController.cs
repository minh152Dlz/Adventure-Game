using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed;
    public float jumpHeight;
    public float fallSpeed;
    public float coyoteTime = 0.1f; // Thời gian linh động sau khi rơi xuống
    public float jumpBufferTime = 0.1f; // Thời gian giữ lại lệnh nhảy
    public AudioSource jumpSound;
    public AudioSource landingSound;
    bool facingRight;
    bool grounded;
    private float coyoteTimeCounter; // Biến đếm thời gian linh động
    private float jumpBufferCounter; // Biến đếm thời gian giữ lại lệnh nhảy

    Rigidbody2D myBody;
    Animator myAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D> ();
        myAnim = GetComponent<Animator> ();
        myBody.gravityScale = fallSpeed;
        facingRight = true;
        coyoteTimeCounter = coyoteTime;
        jumpBufferCounter = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        myAnim.SetFloat("Speed", Mathf.Abs(move));

        myBody.velocity = new Vector2(move*maxSpeed, myBody.velocity.y);

        if(move>0 && !facingRight){
            flip();
        }else if (move<0 && facingRight){
            flip();
        }

        // Coyote time
        if (grounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.fixedDeltaTime;
        }

        // Jump buffering
        if (Input.GetKey(KeyCode.Space))
        {
            jumpBufferCounter += jumpBufferTime;
            jumpSound.Play();
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            //grounded = false;
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);   //Mathf.Min(jumpHeight, myBody.velocity.y + jumpHeight)
            // Reset jump buffer counter
            jumpBufferCounter = 0f;
        }
        
        if (myBody.velocity.y>0f && !Input.GetKey(KeyCode.Space))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y *0.5f);  
            
            // Reset jump buffer counter
            coyoteTimeCounter = 0f;
        }

        
        
    }

    void flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale; 
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            grounded = true;
            landingSound.Play();
        }

    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            grounded = false;
        }
    }

    
}

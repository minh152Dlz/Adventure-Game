using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCharacter : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;
    private Animator myanim;

    private void Awake(){

        playerRb = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
    }
    private void Start()
    {
        startPos = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle")){
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        myanim.SetTrigger("death");
        StartCoroutine(Respawn(1.5f));
    }

    IEnumerator Respawn(float duration){
        
        playerRb.simulated = false;
        playerRb.velocity = new Vector2(0,0);
        
        yield return new WaitForSeconds(duration);
       
        myanim.SetTrigger("alive"); 
        transform.position = startPos;
        playerRb.simulated = true;
        
    }
}


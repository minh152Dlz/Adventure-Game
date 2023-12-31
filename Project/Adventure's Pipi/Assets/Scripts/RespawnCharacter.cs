using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnCharacter : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;

    public Text txtdeath;
    public int deathCount = 0;
    private Animator myanim;
    public AudioSource respawnSound;
    public AudioSource deathSound;
    


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
            deathSound.Play();
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
        deathCount++;
        txtdeath.text = deathCount.ToString();
        Debug.Log('1');
        myanim.SetTrigger("alive"); 
        transform.position = startPos;
        playerRb.simulated = true;
        respawnSound.Play();
        
    }
}


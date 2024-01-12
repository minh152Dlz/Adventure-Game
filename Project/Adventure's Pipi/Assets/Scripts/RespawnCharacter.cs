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
    PlayerAbility playerAbility;

    private void Awake(){
        playerAbility = GetComponent<PlayerAbility>();
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
        deathSound.Play();
        myanim.SetTrigger("death");
        if(playerAbility.check)
        {
            StartCoroutine(Respawn(1.5f));
        }
        else
        {
            gameObject.GetComponent<PlayerController>().enabled = false;
            playerAbility.playerPrefab.GetComponent<PlayerController>().enabled = true;
        }
    }

    IEnumerator Respawn(float duration){
        
        playerRb.simulated = false;
        playerRb.velocity = new Vector2(0,0);
        
        yield return new WaitForSeconds(duration);
        deathCount++;
        txtdeath.text = deathCount.ToString();
        myanim.SetTrigger("alive"); 
        transform.position = startPos;
        playerRb.simulated = true;
        respawnSound.Play();
        
    }
}


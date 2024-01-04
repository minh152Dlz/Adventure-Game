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

    private void Awake(){

        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        startPos = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle")){

            Die();
            deathCount++;
            txtdeath.text = deathCount.ToString();
        }
    }

    // Update is called once per frame
    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }


    IEnumerator Respawn(float duration){
        playerRb.simulated = false;
        playerRb.velocity = new Vector2(0,0);
        transform.localScale = new Vector3(0,0,0);
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        transform.localScale = new Vector3(7,7,1);
        playerRb.simulated = true;
    }
}


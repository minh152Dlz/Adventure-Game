using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCharacter : MonoBehaviour
{
    Vector2 startPos;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        startPos = transform.position;
    }

    private void onTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle")){
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration){
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        spriteRenderer.enabled = true;
    }
}

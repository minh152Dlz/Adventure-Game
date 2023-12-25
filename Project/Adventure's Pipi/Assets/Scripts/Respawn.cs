using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
    }

    privatew void onTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle")){
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Respawn();
    }

    IEnumerator Respawn(float duration){
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RespawnCharacter : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;

    public Text txtdeath;
    public int deathCount = 0;
    public Animator myanim;
    public AudioSource respawnSound;
    public AudioSource deathSound;
    //CameraFollow cameraFollow;


    private void Awake()
    {
        //cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        playerRb = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
            deathSound.Play();
        }
    }

    
    void Die()
    {
        myanim.SetTrigger("white");
        myanim.SetTrigger("death");

       
       

        StartCoroutine(Respawn(1.5f));
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.velocity = Vector2.zero;

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

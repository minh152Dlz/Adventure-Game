using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int ruby = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ruby"))
        {
            if(ruby == 0)
            {
                collision.gameObject.GetComponent<Animator>().SetBool("Rub", true);
                ruby = 1;
            }
        }
    }
}

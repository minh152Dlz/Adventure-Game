using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    
    public GameObject playerPrefab;  // Prefab của nhân vật
    private GameObject playerClone;  // Bản sao của nhân vật

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerClone == null)
            {
                CreatePlayerClone();
            }
            else
            {
                SwitchControl();
            }
        }
    }

    void CreatePlayerClone()
    {
        // Tao ban sao o vi tri hien tai cua nhan vat that
        playerClone = Instantiate(playerPrefab, transform.position, transform.rotation);
        StartCoroutine(EnableControlAfterDelay(1.0f));
    }

    void SwitchControl()
    {
        // Chuyen quyen dieu khien giua nhan vat that va ban sao
        playerClone.GetComponent<PlayerAbility>().enabled = true;
        GetComponent<PlayerAbility>().enabled = false;
    }

    IEnumerator EnableControlAfterDelay(float delay)
    {
        // Cho mot khoang thoi gian truoc khi bat Collider va chuyen quyen dieu khien
        yield return new WaitForSeconds(delay);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<PlayerAbility>().enabled = true;
        playerClone.GetComponent<PlayerAbility>().enabled = false;
    }

}

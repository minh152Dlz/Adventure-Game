using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có tag là "Player" không
        if (collision.CompareTag("Player"))
        {
            // Lấy ra Scenecontroller.instance một lần để tránh việc gọi hàm NextLevel trên một đối tượng null
            Scenecontroller sceneController = Scenecontroller.instance;

            if (sceneController != null)
            {
                // Gọi NextLevel chỉ khi sceneController không phải là null
                sceneController.NextLevel();
            }
            else
            {
                Debug.LogWarning("Scenecontroller.instance is null. Make sure it is properly initialized.");
            }
        }
    }
}

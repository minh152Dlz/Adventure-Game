using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenecontroller : MonoBehaviour
{
    public static Scenecontroller instance;
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(LoadSceneWithTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneWithTransition(sceneName));
    }

    IEnumerator LoadSceneWithTransition(string sceneName)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        
        // Thực hiện chuyển cảnh theo tên
        SceneManager.LoadScene(sceneName);

        // Đặt lại trigger của Animator cho hiệu ứng chuyển cảnh
        transitionAnim.SetTrigger("Start");
    }

    IEnumerator LoadSceneWithTransition(int sceneBuildIndex)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        // Thực hiện chuyển cảnh theo index
        SceneManager.LoadScene(sceneBuildIndex);

        // Đặt lại trigger của Animator cho hiệu ứng chuyển cảnh
        transitionAnim.SetTrigger("Start");
    }
}

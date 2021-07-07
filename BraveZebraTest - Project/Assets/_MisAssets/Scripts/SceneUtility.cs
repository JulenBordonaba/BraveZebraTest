using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtility : MonoBehaviour
{
    #region Methods
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadSceneAsync(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void LoadSceneAsync(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}

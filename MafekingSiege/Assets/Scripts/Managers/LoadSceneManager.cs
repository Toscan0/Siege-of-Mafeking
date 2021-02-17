using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeOut;

    internal void LoadNextScene()
    {
        fadeOut.SetActive(true);

        StartCoroutine(LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadSceneByIndex(int indx)
    {
        yield return new WaitForSeconds(0.45f);
        SceneManager.LoadScene(indx);
    }
}
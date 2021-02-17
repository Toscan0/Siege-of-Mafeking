using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private LoadSceneManager loadSceneManager;

    public void Play()
    {
        loadSceneManager.LoadNextScene();
    }
}

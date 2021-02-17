using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private LoadSceneManager loadSceneManager;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();    
    }

    public void Play()
    {
        loadSceneManager.LoadNextScene();
    }

    public void SetInteractable(bool b)
    {
        button.interactable = b;
    }
}

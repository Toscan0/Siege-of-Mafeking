using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private AudioClip gameEnd;
    [SerializeField]
    private LoadSceneManager loadSceneManager;

    private AudioSource audioSorce;

    private void Awake()
    {
        TimerManager.OnTimeOver += GameEnded;
        PlayerManager.OnPlayerDeath += GameEnded;

        audioSorce = GetComponent<AudioSource>();
    }

    private void GameEnded()
    {
        PlaySound(gameEnd);

        loadSceneManager.LoadNextScene();
    }

    private void OnDestroy()
    {
        TimerManager.OnTimeOver -= GameEnded;
        PlayerManager.OnPlayerDeath -= GameEnded;
    }

    internal void PlaySound(AudioClip audioClip)
    {
        audioSorce.clip = audioClip;
        audioSorce.Play();
    }
}

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BombSoundManager : MonoBehaviour
{
    private AudioSource audioSorce;

    private void Awake()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    internal void PlaySound(AudioClip audioClip)
    {
        audioSorce.clip = audioClip;
        audioSorce.Play();
    }
}

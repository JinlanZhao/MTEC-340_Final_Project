using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SequentialBackgroundMusic : MonoBehaviour
{
    [Header("Background Music Tracks")]
    public AudioClip scence1;
    public AudioClip scence2;

    [Header("Fade In Settings")]
    public float fadeInDuration = 3f;
    public float targetVolume = 0.2f;

    private AudioSource audioSource;
    private static SequentialBackgroundMusic instance;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = 0f;
    }

    void Start()
    {
        if (scence1 == null && scence2 == null) return;
        StartCoroutine(PlayTracksInSequence());
    }

    public static void TriggerFadeIn()
    {
        if (instance == null) return;
        instance.StartCoroutine(instance.FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, targetVolume, elapsed / fadeInDuration);
            yield return null;
        }
        audioSource.volume = targetVolume;
    }

    IEnumerator PlayTracksInSequence()
    {
        while (true)
        {
            yield return PlayClip(scence1);
            yield return PlayClip(scence2);
        }
    }

    IEnumerator PlayClip(AudioClip clip)
    {
        if (clip == null) yield break;
        audioSource.clip = clip;
        audioSource.Play();
        while (audioSource.isPlaying) yield return null;
    }
}
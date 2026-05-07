using UnityEngine;

public class SequentialAudioPlayer : MonoBehaviour
{
    [Header("Audio Clips (in order)")]
    public AudioClip[] clips;

    [Header("Membrane ID (A or B)")]
    public string membraneID;

    private static string lastTriggered = "";

    private AudioSource audioSource;
    private int currentIndex = 0;
    private bool hasLeft = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!hasLeft) return;
        if (lastTriggered == membraneID) return;

        if (currentIndex < clips.Length)
        {
            audioSource.PlayOneShot(clips[currentIndex]);
            currentIndex++;
        }

        hasLeft = false;
        lastTriggered = membraneID;
        OrbController.RegisterTrigger();

        if (currentIndex == 3)
        {
            SequentialBackgroundMusic.TriggerFadeIn();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        hasLeft = true;
    }
}
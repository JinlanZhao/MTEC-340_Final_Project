using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    [Header("Ending Light")]
    public Light directionalLight;
    public float lightFadeDuration = 5f;
    public float targetLightIntensity = 1f;

    private bool isPaused = false;

    void Start()
    {
        pauseCanvas.SetActive(false);
        volumeSlider.value = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void TriggerLightFadeIn()
    {
        PauseMenu pm = FindFirstObjectByType<PauseMenu>();
        if (pm == null) return;
        pm.StartCoroutine(pm.FadeInLight());
    }

    public IEnumerator FadeInLight()
    {
        if (directionalLight == null) yield break;
        directionalLight.gameObject.SetActive(true);
        directionalLight.intensity = 0f;

        Color startAmbient = RenderSettings.ambientLight;
        Color targetAmbient = new Color(0.5f, 0.5f, 0.5f);

        float elapsed = 0f;
        while (elapsed < lightFadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / lightFadeDuration;
            directionalLight.intensity = Mathf.Lerp(0f, targetLightIntensity, t);
            RenderSettings.ambientLight = Color.Lerp(startAmbient, targetAmbient, t);
            yield return null;
        }

        directionalLight.intensity = targetLightIntensity;
        RenderSettings.ambientLight = targetAmbient;
    }
}
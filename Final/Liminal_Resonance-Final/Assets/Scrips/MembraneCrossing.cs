using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MembraneCrossing : MonoBehaviour
{
    [Header("Screen Flash")]
    public Image flashImage;
    public float flashAlpha = 0.4f;
    public float flashFadeDuration = 0.8f;

    [Header("FOV Pulse")]
    public float fovBoost = 15f;
    public float fovFadeDuration = 0.6f;

    [Header("Cooldown")]
    public float cooldown = 3f;

    private float baseFov;
    private bool onCooldown = false;

    void Start()
    {
        baseFov = Camera.main.fieldOfView;

        if (flashImage != null)
        {
            var c = flashImage.color;
            c.a = 0f;
            flashImage.color = c;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (onCooldown || !other.CompareTag("Player")) return;
        StartCoroutine(EffectsRoutine());
    }

    IEnumerator EffectsRoutine()
    {
        onCooldown = true;

        StartCoroutine(ScreenFlash());
        StartCoroutine(FovPulse());

        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }

    IEnumerator ScreenFlash()
    {
        SetFlashAlpha(flashAlpha);

        float elapsed = 0f;
        while (elapsed < flashFadeDuration)
        {
            elapsed += Time.deltaTime;
            SetFlashAlpha(Mathf.Lerp(flashAlpha, 0f, elapsed / flashFadeDuration));
            yield return null;
        }

        SetFlashAlpha(0f);
    }

    IEnumerator FovPulse()
    {
        Camera.main.fieldOfView = baseFov + fovBoost;

        float elapsed = 0f;
        while (elapsed < fovFadeDuration)
        {
            elapsed += Time.deltaTime;
            Camera.main.fieldOfView = Mathf.Lerp(baseFov + fovBoost, baseFov, elapsed / fovFadeDuration);
            yield return null;
        }

        Camera.main.fieldOfView = baseFov;
    }

    void SetFlashAlpha(float a)
    {
        if (flashImage == null) return;
        var c = flashImage.color;
        c.a = a;
        flashImage.color = c;
    }
}

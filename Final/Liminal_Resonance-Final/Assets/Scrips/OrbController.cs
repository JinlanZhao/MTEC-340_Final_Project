using UnityEngine;
using System.Collections;

public class OrbController : MonoBehaviour
{
    [Header("Scale")]
    public float minScale = 0.1f;
    public float maxScale = 3.0f;

    [Header("Alpha")]
    public float minAlpha = 0.0f;
    public float maxAlpha = 0.75f;

    [Header("Float Animation")]
    public float floatSpeed = 0.8f;
    public float floatAmount = 0.08f;

    [Header("Steps")]
    public int totalSteps = 10;

    private static OrbController instance;
    private Material mat;
    private Vector3 originPos;
    private int currentStep = 0;
    private bool hasExploded = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        originPos = transform.position;
        UpdateOrb();
    }

    void Update()
    {
        if (hasExploded) return;
        float floatY = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.position = originPos + new Vector3(0, floatY, 0);
    }

    public static void RegisterTrigger()
    {
        if (instance == null) return;
        instance.currentStep++;
        instance.UpdateOrb();
    }

    void UpdateOrb()
    {
        float t = (float)currentStep / totalSteps;

        float scale = Mathf.Lerp(minScale, maxScale, t);
        transform.localScale = Vector3.one * scale;
        
        mat.SetFloat("_EmissionIntensity", Mathf.Lerp(2.0f, 8.0f, t));
        mat.SetFloat("_OrbAlpha", Mathf.Lerp(minAlpha, maxAlpha, t));

        if (currentStep >= totalSteps && !hasExploded)
        {
            hasExploded = true;
            StartCoroutine(ShakeThenExplode());
        }
    }

    IEnumerator ShakeThenExplode()
    {
        float shakeDuration = 5.0f;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;
            float intensity = Mathf.Lerp(0.005f, 0.08f, elapsed / shakeDuration);
            transform.position = originPos + Random.insideUnitSphere * intensity;
            yield return null;
        }

        transform.position = originPos;
        GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.4f);
        foreach (var renderer in GetComponentsInChildren<MeshRenderer>())
        {
            renderer.enabled = false;
        }
    }
}
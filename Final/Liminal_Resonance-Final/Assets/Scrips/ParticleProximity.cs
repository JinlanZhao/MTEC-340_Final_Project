using UnityEngine;

public class ParticleProximity : MonoBehaviour
{
    public Transform player;
    public Transform membranB;

    [Header("Distance Range")]
    public float maxDistance = 5f;
    public float minDistance = 1f;

    [Header("Emission Rate")]
    public float emissionRateNear = 40f;
    public float emissionRateFar = 5f;

    [Header("Start Speed")]
    public float startSpeedNear = 0.05f;
    public float startSpeedFar = 0.5f;

    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, membranB.position);

        var emission = ps.emission;
        var main = ps.main;

        if (dist >= maxDistance)
        {
            emission.rateOverTime = 0f;
            return;
        }

        float t = Mathf.InverseLerp(maxDistance, minDistance, dist);
        emission.rateOverTime = Mathf.Lerp(emissionRateFar, emissionRateNear, t);
        main.startSpeed = Mathf.Lerp(startSpeedFar, startSpeedNear, t);
    }
}

using UnityEngine;

public class MembraneLight : MonoBehaviour
{
    public Transform player;
    public Transform membrane;

    public float maxDistance = 5f;
    public float minDistance = 1f;
    public float intensityFar = 1f;
    public float intensityNear = 8f;

    private Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, membrane.position);

        if (dist >= maxDistance)
        {
            lt.intensity = intensityFar;
            return;
        }

        float t = Mathf.InverseLerp(maxDistance, minDistance, dist);
        lt.intensity = Mathf.Lerp(intensityFar, intensityNear, t);
    }
}

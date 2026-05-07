using UnityEngine;

public class MembraneProximity : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float maxIntensity = 8f;
    [SerializeField] private float falloffPower = 2f;

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        float t = 1f - Mathf.Clamp01(distance / maxDistance);
        float intensity = maxIntensity * Mathf.Pow(t, falloffPower);
        _material.SetFloat("_EmissionIntensity", intensity);
    }
}

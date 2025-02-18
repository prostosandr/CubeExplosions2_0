using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceTreshold;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private Renderer _renderer;

    public float ChanceTreshold => _chanceTreshold;
    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        ChangeColor();
    }

    public void Init(float newChanceTreshold, float newExplosionForce, float newExplosionRadius)
    {
        _chanceTreshold = newChanceTreshold;
        _explosionForce = newExplosionForce;
        _explosionRadius = newExplosionRadius;
    }

    private void ChangeColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
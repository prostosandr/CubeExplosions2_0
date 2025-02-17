using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceTreshold;

    private Renderer _renderer;

    public float ChanceTreshold => _chanceTreshold;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        ChangeColor();
    }

    public void SetChanceTreshold(float newChanceTreshold)
    {
        _chanceTreshold = newChanceTreshold;
    }

    private void ChangeColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
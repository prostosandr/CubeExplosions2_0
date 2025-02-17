using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [SerializeField] private MouseKeyReader _mouseKeyReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _detonator;

    private void OnEnable()
    {
        _mouseKeyReader.Clicked += Work;
    }

    private void OnDisable()
    {
        _mouseKeyReader.Clicked -= Work;
    }

    private void Work(Cube cube)
    {
        int divisor = 2;

        if (TrySpawn(cube.ChanceTreshold))
            _detonator.Explode(_spawner.Spawn(cube, GetTramsform(cube.transform, divisor), GetChance(cube.ChanceTreshold, divisor)), cube.transform.position);

        Destroy(cube.gameObject);
    }

    private float GetChance(float chanceTreshold, int divisor)
    {
        return chanceTreshold / divisor;
    }

    private Transform GetTramsform(Transform cubeTransform, int divisor)
    {
        cubeTransform.localScale /= divisor;

        return cubeTransform;
    }

    private bool TrySpawn(float chanceTreshold)
    {
        int minNumberOfChance = 0;
        int maxNumberOfChance = 100;

        return Random.Range(minNumberOfChance, maxNumberOfChance) <= chanceTreshold;
    }
}
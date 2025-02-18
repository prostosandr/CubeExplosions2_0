using UnityEngine;

public class CubesInteraction : MonoBehaviour
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

        Transform cubeTransform = GetTransform(cube.transform, divisor);

        if (GetPermitSpawn(cube.ChanceTreshold))
            _spawner.Spawn(cube, cubeTransform, GetChance(cube.ChanceTreshold, divisor), GetExplosionForce(cube.ExplosionForce, divisor), GetExplosionRadius(cube.ExplosionRadius, divisor));
        else
            _detonator.Explode(cubeTransform.position, cube.ExplosionForce, cube.ExplosionRadius);

        Destroy(cube.gameObject);
    }

    private float GetExplosionForce(float explosionForce, int divisor)
    {
        return explosionForce * divisor;
    }

    private float GetExplosionRadius(float explosionRadius, int divisor)
    {
        return explosionRadius * divisor;
    }
    private float GetChance(float chanceTreshold, int divisor)
    {
        return chanceTreshold / divisor;
    }

    private bool GetPermitSpawn(float chanceTreshold)
    {
        int minNumberOfChance = 0;
        int maxNumberOfChance = 100;

        return Random.Range(minNumberOfChance, maxNumberOfChance) <= chanceTreshold;
    }

    private Transform GetTransform(Transform cubeTransform, int divisor)
    {
        cubeTransform.localScale /= divisor;

        return cubeTransform;
    }
}
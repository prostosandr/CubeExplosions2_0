using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minNumberOfCube;
    [SerializeField] private int _maxNumberOfCube;

    public void Spawn(Cube oldCube, Transform cubeTraform, float chanceTreshold, float explosionForce, float explosionRadius)
    {
        for (int i = 0; i < Random.Range(_minNumberOfCube, _maxNumberOfCube); i++)
        {
            Cube newCube = Instantiate(oldCube, cubeTraform.position, cubeTraform.rotation);
            newCube.transform.localScale = cubeTraform.localScale;
            newCube.SetChanceTreshold(chanceTreshold);
            newCube.SetExplosionParameter(explosionForce, explosionRadius);
        }
    }
}
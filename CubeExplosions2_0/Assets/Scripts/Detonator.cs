using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    private float _maxExplosionForce;
    private float _explosionRadius;

    public void Explode(Vector3 ñubePosition, float maxExplosionForce, float explosionRadius)
    {
       SetParameter(maxExplosionForce, explosionRadius);

        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(GetExplosionForce(ñubePosition, explodableObject.transform.position), ñubePosition, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> explodableObject = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                explodableObject.Add(hit.attachedRigidbody);

        return explodableObject;
    }

    private float GetExplosionForce(Vector3 cubePosition, Vector3 explodableObjectPosition)
    {
        float minExplosionForce = 0;
        float distance = Mathf.Sqrt((cubePosition - explodableObjectPosition).sqrMagnitude);

        return Mathf.Lerp(_maxExplosionForce, minExplosionForce, distance / _explosionRadius);
    }

    private void SetParameter(float MaxExplosionForce, float explosionRadius)
    {
        _maxExplosionForce = MaxExplosionForce;
        _explosionRadius = explosionRadius;
    }
}
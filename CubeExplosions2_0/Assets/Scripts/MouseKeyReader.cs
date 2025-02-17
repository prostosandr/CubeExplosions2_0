using System;
using UnityEngine;

public class MouseKeyReader : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public event Action<Cube> Clicked;

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.TryGetComponent(out Cube cube))
            {
                Clicked?.Invoke(cube);
            }
        }
    }
}
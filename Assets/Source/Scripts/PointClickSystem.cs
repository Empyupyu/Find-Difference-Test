using System.Linq;
using UnityEngine;

public class PointClickSystem : MonoBehaviour
{
    public Level level;

    private Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        TryHitCollider();
    }

    private void TryHitCollider()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (level == null)
            level = FindAnyObjectByType<Level>();

        Vector3 mousePosition = Input.mousePosition - _mainCamera.transform.position;
        var hit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(mousePosition));

        if (hit.collider == null) return;
        if (!hit.collider.TryGetComponent(out DifferenceObject differenceObject)) return;

        CheckDifference(differenceObject);
    }

    private void CheckDifference(DifferenceObject differenceObject)
    {
        var obj = level.DifferenceObjects.FirstOrDefault(o => o.Equals(differenceObject));
        if (obj == null) return;

        Debug.Log("Find difference object " + obj.name);
   
        level.RemoveFindObject(obj);
    }
}

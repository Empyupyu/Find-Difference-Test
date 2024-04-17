using Supyrb;
using System.Linq;
using UnityEngine;

public class PointClickSystem : GameSystem
{
    private Camera _mainCamera;

    public override void OnStart()
    {
        _mainCamera = Camera.main;
    }

    public override void OnUpdate()
    {
        TryHitCollider();
    }

    private void TryHitCollider()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Vector3 mousePosition = Input.mousePosition - _mainCamera.transform.position;
        var hit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(mousePosition));

        if (hit.collider == null) return;
        if (!hit.collider.TryGetComponent(out DifferenceObject differenceObject)) return;

        CheckDifference(differenceObject);
    }

    private void CheckDifference(DifferenceObject differenceObject)
    {
        var obj = _gameData.Level.DifferenceObjects.FirstOrDefault(o => o.Equals(differenceObject));
        if (obj == null) return;

        Debug.Log("Find difference object " + obj.name);

        _gameData.Level.RemoveFindObject(obj);

        Signals.Get<SpawnEffectSignal>()?.Dispatch(obj);

        if (_gameData.Level.DifferenceObjects.Count != 0) return;

        _gameData.OnFindAllDefferenceObjects?.Dispatch();
    } 
}

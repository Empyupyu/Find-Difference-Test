using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [field: SerializeField] public List<DifferenceObject> DifferenceObjects { get; private set; }
    [field: SerializeField] public Transform OriginScreen { get; private set; }

    public void RemoveFindObject(DifferenceObject differenceObject)
    {
        differenceObject.gameObject.SetActive(false);
        DifferenceObjects.Remove(differenceObject);
    }
}

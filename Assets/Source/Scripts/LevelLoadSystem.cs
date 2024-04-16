using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelLoadSystem : MonoBehaviour
{
    private GameObject _level;

    async void Start()
    {
        var level = await LoadLevel<Level>("Level 1");
    }

    protected async Task<T> LoadLevel<T>(string assetID)
    {
        var asset = Addressables.InstantiateAsync(assetID);
        _level = await asset.Task;

        if (_level.TryGetComponent(out T level) == false)
            throw new NullReferenceException();

        return level;
    }
}

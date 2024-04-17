using Supyrb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelLoadSystem : MonoBehaviour
{
    private Level _level;

    private void Start()
    {
        LoadLevel("Level 1");

        Signals.Get<RestartSignal>().AddListener(Restart);
    }

    private async void LoadLevel(string assetID)
    {
        var asset = Addressables.InstantiateAsync(assetID);
        var load = await asset.Task;

        if (load.TryGetComponent(out Level level) == false)
            throw new NullReferenceException();

        _level = level;
    }

    private void Restart()
    {
        Destroy(_level.gameObject);
        LoadLevel("Level 1");
    }
}

using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class LevelLoadSystem : GameSystem
{
    [SerializeField] private LevelView _levelView;

    public override void OnStart()
    {
        LoadLevel("Level 1");

        _gameData.RestartSignal.AddListener(Restart);
    }

    private async void LoadLevel(string assetID)
    {
        var asset = Addressables.InstantiateAsync(assetID);
        var load = await asset.Task;

        if (load.TryGetComponent(out Level level) == false)
            throw new NullReferenceException();

        _gameData.Level = level;

        _levelView.UpdateLevel(_playerData.Level);
    }

    private void Restart()
    {
        _playerData.Level++;

        Destroy(_gameData.Level.gameObject);
        LoadLevel("Level 1");

        Bootstrap.Instance.SaveGame();
    }
}

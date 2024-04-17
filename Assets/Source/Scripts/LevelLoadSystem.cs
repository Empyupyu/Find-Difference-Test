using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelLoadSystem : GameSystem
{
    [SerializeField] private LevelView _levelView;

    private int _levelNumber => _configData.MaximumLevel < _playerData.Level ? _configData.MaximumLevel : _playerData.Level + 1;

    public override void OnStart()
    {
        LoadLevel();

        _gameData.RestartSignal.AddListener(Restart);
    }

    private async void LoadLevel()
    {
        var asset = Addressables.InstantiateAsync($"Level {_levelNumber}");
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
        LoadLevel();

        Bootstrap.Instance.SaveGame();
    }
}

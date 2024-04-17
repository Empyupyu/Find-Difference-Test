using UnityEngine;

public abstract class GameSystem : MonoBehaviour
{
    protected GameData _gameData { get; private set; }
    protected PlayerData _playerData { get; private set; }
    protected ConfigData _configData { get; private set; }

    public void InitializeDatas(GameData game, PlayerData player, ConfigData config)
    {
        _gameData = game;
        _playerData = player;
        _configData = config;
    }

    public virtual void OnAwake() { }
    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
}


using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static Bootstrap Instance { get; private set; }

    public GameData GameData { get; } = new GameData();
    public PlayerData PlayerData { get; private set; } = new PlayerData();

    [SerializeField] private ConfigData _configData;

    private List<GameSystem> _gameSystems = new List<GameSystem>();

    private const string SAVE_GAME = "SaveGame";

    public void SaveGame()
    {
        SaveUtility.Instance().Save(SAVE_GAME, PlayerData);
    }

    public GameSystem GetGameSystem<T>() where T : GameSystem
    {
        return _gameSystems.FirstOrDefault(x => x.GetType() == typeof(T));
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        LoadGame();
        AddSystems();
        InitializeSystemDatas();
        OnAwake();
    }

    private void AddSystems()
    {
        _gameSystems.AddRange(transform.GetComponentsInChildren<GameSystem>());
    }

    // Инициализацию можно было бы реализовать через Zenject, для уменьшения связанности.
    private void InitializeSystemDatas()
    {
        for (int i = 0; i < _gameSystems.Count; i++)
            _gameSystems[i].InitializeDatas(GameData, PlayerData, _configData);
    }

    private void Start()
    {
        foreach (var system in _gameSystems)
            system.OnStart();
    }

    private void LoadGame()
    {
        if (!SaveUtility.Instance().HasSave(SAVE_GAME)) return;

        PlayerData = SaveUtility.Instance().Load<PlayerData>(SAVE_GAME);
    }

    private void OnAwake()
    {
        foreach (var system in _gameSystems)
            system.OnAwake();
    }

    private void Update()
    {
        foreach (var system in _gameSystems)
            system.OnUpdate();
    }
}


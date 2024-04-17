using UnityEngine;

public class TimerSystem : GameSystem
{
    [SerializeField] private TimerView _timerView;

    public override void OnStart()
    {
        _gameData.RestartSignal.AddListener(ResetTimer);

        ResetTimer();
    }

    private void ResetTimer()
    {
        _gameData.CurrentTimer = _configData.LevelTimer;
    }

    public override void OnUpdate()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (_gameData.CurrentTimer == 0 || _gameData.GameIsOver) return;

        float tick = _gameData.CurrentTimer - Time.deltaTime;
        _gameData.CurrentTimer = tick;

        if (_gameData.CurrentTimer < 0)
        {
            _gameData.CurrentTimer = 0;

            Debug.Log("You lose =(");
            _gameData.TimeOverSignal?.Dispatch();
        }

        _timerView.UpdateView(_gameData.CurrentTimer);
    }
}

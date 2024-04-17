using UnityEngine;

public class TimerSystem : GameSystem
{
    [SerializeField] private TimerView _timerView;
    private float _currentTime;

    public override void OnStart()
    {
        _gameData.RestartSignal.AddListener(ResetTimer);

        ResetTimer();
    }

    private void ResetTimer()
    {
        _currentTime = _configData.LevelTimer;
    }

    public override void OnUpdate()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (_currentTime == 0 || _gameData.GameIsOver) return;

        float tick = _currentTime - Time.deltaTime;
        _currentTime = tick;

        if (_currentTime < 0)
        {
            _currentTime = 0;

            Debug.Log("You lose =(");
            _gameData.TimeOverSignal?.Dispatch();
        }

        _timerView.UpdateView(_currentTime);
    }
}

using Supyrb;

public class GameData
{
    public TimeOverSignal TimeOverSignal = Signals.Get<TimeOverSignal>();
    public OnFindAllDefferenceObjectSignal OnFindAllDefferenceObjects = Signals.Get<OnFindAllDefferenceObjectSignal>();
    public RestartSignal RestartSignal = Signals.Get<RestartSignal>();
    public OnGameRestartedSignal OnGameRestartedSignal = Signals.Get<OnGameRestartedSignal>();


    public Level Level;

    public bool GameIsOver;
    public float CurrentTimer;
}


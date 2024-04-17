using Supyrb;

public class GameData
{
    public TimeOverSignal TimeOverSignal = Signals.Get<TimeOverSignal>();
    public OnFindAllDefferenceObjects OnFindAllDefferenceObjects = Signals.Get<OnFindAllDefferenceObjects>();
    public RestartSignal RestartSignal = Signals.Get<RestartSignal>();

    public Level Level;

    public bool GameIsOver;
    public float CurrentTimer;
}


using Supyrb;

public class GameData
{
    public Level Level;
    public TimeOverSignal TimeOverSignal = Signals.Get<TimeOverSignal>();
    public OnFindAllDefferenceObjects OnFindAllDefferenceObjects = Signals.Get<OnFindAllDefferenceObjects>();
    public RestartSignal RestartSignal = Signals.Get<RestartSignal>();

    public bool GameIsOver;
}


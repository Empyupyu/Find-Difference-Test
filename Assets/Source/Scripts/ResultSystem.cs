using UnityEngine;

public class ResultSystem : GameSystem
{
    [SerializeField] private ResultScreen _resultScreen;

    public override void OnStart()
    {
        _gameData.TimeOverSignal.AddListener(Lose);
        _gameData.OnFindAllDefferenceObjects.AddListener(Win);

        _resultScreen.RestartButton.onClick.AddListener(Restart);
    }

    private void Win()
    {
        SetGameStatus(true);

        _resultScreen.UpdateWinResult();
        _resultScreen.Open();
    }

    private void Lose()
    {
        SetGameStatus(true);

        _resultScreen.UpdateLoseResult();
        _resultScreen.Open();
    }

    private void Restart()
    {
        _resultScreen.Close();
        _gameData.RestartSignal.Dispatch();

        SetGameStatus(false);
    }

    private void SetGameStatus(bool gameIsOver)
    {
        _gameData.GameIsOver = gameIsOver;
    }
}

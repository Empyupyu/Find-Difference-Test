using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    [field: SerializeField] public Button RestartButton { get; private set; }

    [SerializeField] private TextMeshProUGUI _resultText;

    public void UpdateWinResult()
    {
        _resultText.text = "You Win!";
    }

    public void UpdateLoseResult()
    {
        _resultText.text = "You Lose =(";
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}



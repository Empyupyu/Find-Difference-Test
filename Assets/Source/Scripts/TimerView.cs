using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public void UpdateView(float value)
    {
        float min = Mathf.FloorToInt(value / 60);
        float sec = Mathf.FloorToInt(value % 60);

        _timerText.text = "Time: " + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec);
    }
}



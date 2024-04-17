using Supyrb;
using System.Collections;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    private float _startTime = 120;
    public float _currentTime;

    void Start()
    {
        Signals.Get<RestartSignal>().AddListener(ResetTimer);

        ResetTimer();
    }

    private void ResetTimer()
    {
        _currentTime = _startTime;
    }

    private void Update()
    {
        float tick = _currentTime - Time.deltaTime;
        _currentTime = tick;

        if(_currentTime < 0)
        {
            _currentTime = 0;
           
            Debug.Log("You lose =(");
        }      
    }
}

using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private UnityEvent TimerFinishedEvent;
    [SerializeField] private UnityEvent<string> TimeLeftTextEvent;
    [SerializeField] private float startTime;
    private float timeLeft;
    private bool running;

    private void Start()
    {
        if (startTime > 0)
        {
            SetTimer(startTime, true);
        }
    }

    public void SetTimer(float time, bool start)
    {
        timeLeft = time;
        if (start)
        {
            running = true;
        }
    }

    public void PauseTimer()
    {
        running = false;
    }

    public void ResumeTimer()
    {
        running = true;
    }

    private void Update()
    {
        if (!running)
        {
            return;
        }
        timeLeft -= Time.deltaTime;
        TimeLeftTextEvent?.Invoke(timeLeft.ToString("0.00"));
        if (timeLeft <= 0)
        {
            TimerFinishedEvent?.Invoke();
            running = false;
        }
    }
}

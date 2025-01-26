using UnityEngine;
using UnityEngine.Events;

public class BreathingController : MonoBehaviour
{
    [SerializeField] UnityEvent OnBreathInEvent;
    [SerializeField] UnityEvent OnHoldEvent;
    [SerializeField] UnityEvent OnBreathOutEvent;
    [SerializeField] int MaxCount;
    [SerializeField] int _count;
    [SerializeField] UnityEvent OnEndCountEvent;
    public void BreathIn()
    {
        OnBreathInEvent.Invoke();
    }
    public void Hold()
    {
        OnHoldEvent.Invoke();
    }
    public void BreathOut()
    {
        OnBreathOutEvent.Invoke();
    }
    private void Start()
    {
        _count = 0;
    }
    public void Count()
    {
        ++_count;
        if(_count >= MaxCount)
        {
            OnEndCountEvent.Invoke();
        }
    }
}

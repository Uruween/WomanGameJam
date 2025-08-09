using UnityEngine;
using UnityEngine.Events;

public abstract class Steap : MonoBehaviour
{
    [SerializeField] UnityEvent starEvents;
    [SerializeField] UnityEvent finishEvents;

    private void Start()
    {
        InvokeStartEvents();
    }

    public void InvokeStartEvents()
    {
        starEvents.Invoke();    
    }

    public void InvokeFinishEvents()
    {
        finishEvents.Invoke();
    }
}

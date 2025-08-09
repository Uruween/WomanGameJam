using UnityEngine;

public class InputStep : Steap
{
    [SerializeField] KeyCode key;

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            InvokeFinishEvents();
        }
    }
}

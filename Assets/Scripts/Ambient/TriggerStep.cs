using System.Collections.Generic;
using UnityEngine;

public class TriggerStep : Steap
{
    [SerializeField] List<string> tags = new();
    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            InvokeFinishEvents();
        }
    }
}

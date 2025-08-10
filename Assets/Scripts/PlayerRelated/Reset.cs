using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] GameObject tp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            other.transform.position = tp.transform.position;
    }
}

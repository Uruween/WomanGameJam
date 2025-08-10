using UnityEngine;

public class ChangeDoor : MonoBehaviour
{
  [SerializeField] Door door;


    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("Player"))
        door.ChangeState();
    }
}

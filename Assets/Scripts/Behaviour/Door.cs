using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool doorOpen = false;
    [SerializeField] float doorOpenAngle;
    [SerializeField] float doorCloseAngle;
    [SerializeField] float smooth;

    private void Update()
    {
        if (doorOpen)
        {
            Quaternion _targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, _targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion _targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, _targetRotation2, smooth * Time.deltaTime);
        }
    }

    public void ChangeState()
    {
        doorOpen = !doorOpen;
    }
}

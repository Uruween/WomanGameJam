using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] bool doorOpen = false;
    [SerializeField] Transform doorOpenAngle;
    [SerializeField] Transform doorCloseAngle;
    [SerializeField] float smooth;
    [SerializeField] GameObject brillito;
    [SerializeField] UnityEvent eventosAbierta;

    private void Awake()
    {
        doorOpenAngle.SetParent(null);
        doorCloseAngle.SetParent(null);
    }
    private void Update()
    {
        if (doorOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, doorOpenAngle.rotation, smooth * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, doorCloseAngle.rotation, smooth * Time.deltaTime);
        }
    }

    public void ChangeState()
    {
        doorOpen = !doorOpen;
        eventosAbierta?.Invoke();
    }
    public void HabilitarBrillo(bool activado)
    {
        brillito?.SetActive(activado);
    }
}

using UnityEngine;
using System.Collections.Generic;

public class Colors : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] GameObject image;

    Door lastDoor;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.collider.tag == "Door")
            {
                lastDoor = hit.collider.transform.GetComponent<Door>();

                if (Input.GetKeyDown(KeyCode.F))
                {
                    lastDoor.ChangeState();
                }

                if (hit.distance <= 2)
                {
                    lastDoor.HabilitarBrillo(true);
                    image.SetActive(true);
                }
            }
        }
        else
        {
            if (image.activeSelf)
            {
                if (lastDoor)
                {
                    lastDoor.HabilitarBrillo(false);
                    lastDoor = null;
                }

                image.SetActive(false);
            }
        }
    }
}

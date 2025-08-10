using UnityEngine;
using System.Collections.Generic;

public class Colors : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] GameObject image;


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.collider.tag == "Door")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    hit.collider.transform.GetComponent<Door>().ChangeState();
                }

                if (hit.distance <= 2)
                {
                    image.SetActive(true);
                }
            }
        }
        else
        {
            if (image.activeSelf)
            {
                image.SetActive(false);
            }
        }
    }
}

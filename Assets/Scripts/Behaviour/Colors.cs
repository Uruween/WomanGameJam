using UnityEngine;
using System.Collections.Generic;

public class Colors : MonoBehaviour
{
    [SerializeField] float distance;


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if(hit.collider.tag == "Door")
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    hit.collider.transform.GetComponent<Door>().ChangeState();
                }
            }
        }
    }
}

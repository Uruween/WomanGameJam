using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.UIElements;

public class CamaraControler : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] Transform player;
    [SerializeField] float sensibility;
    [SerializeField] float xRotation;
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;

        player.Rotate(player.transform.up * mouseX);

        xRotation = Mathf.Clamp(xRotation, -30f, 30f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
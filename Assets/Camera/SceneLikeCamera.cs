using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLikeCamera : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private float zoomSpeed = 15.0f;
    
    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode backwardKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode leftRotationKey = KeyCode.E;
    [SerializeField] private KeyCode rightRotationKey = KeyCode.Q;

    [SerializeField] private KeyCode anchoredRotateKey = KeyCode.Mouse1;
    private void FixedUpdate()
    {
        Vector3 move = Vector3.zero;
        if (Input.GetKey(forwardKey))
        {
            move += Vector3.forward * moveSpeed;
        }
        if (Input.GetKey(backwardKey))
        {
            move += Vector3.back * moveSpeed;
        }
        if (Input.GetKey(leftKey))
        {
            move += Vector3.left * moveSpeed;
        }
        if (Input.GetKey(rightKey))
        {
            move += Vector3.right* moveSpeed;
        }
        
        float rotateDir = 0f;

        if (Input.GetKey(leftRotationKey))
        {
            rotateDir = +10f;
        }
        if (Input.GetKey(rightRotationKey))
        {
            rotateDir = -10f;
        }

        transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);

        float mouseMoveY = Input.GetAxis("Mouse Y");
        float mouseMoveX = Input.GetAxis("Mouse X");

        if (Input.GetKey(anchoredRotateKey))
        {
            transform.RotateAround(transform.position, transform.right, mouseMoveY * -rotateSpeed);
            transform.RotateAround(transform.position, Vector3.up, mouseMoveX * rotateSpeed);
        }
        
        
        transform.Translate(move);
    }

    private void LateUpdate()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * mouseScroll * zoomSpeed);
    }
}

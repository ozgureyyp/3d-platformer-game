using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; 
    public Vector3 offset;


    void Update()
    {
        this.transform.position = playerTransform.position + offset;
    }
}

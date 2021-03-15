using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotater : MonoBehaviour
{
    // Start is called before the first frame update
    public bool rotateX, rotateY, rotateZ;
    public float rotateSpeedX, rotateSpeedY, rotateSpeedZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spinning();
    }

    void Spinning()
    {
        if (rotateX)
            transform.Rotate(Vector3.right * (rotateSpeedX * Time.deltaTime));
        if (rotateY)
            transform.Rotate(Vector3.up * (rotateSpeedY * Time.deltaTime));
        if (rotateZ)
            transform.Rotate(Vector3.forward * (rotateSpeedZ * Time.deltaTime));
    }
}

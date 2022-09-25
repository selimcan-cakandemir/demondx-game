using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    private float mag;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        ReturnMagnitude();
    }

    void ReturnMagnitude()
    {
        Vector3 vector = transform.position;
        mag = vector.magnitude;
        Debug.Log(mag);
    }
}

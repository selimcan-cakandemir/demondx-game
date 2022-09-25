using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class Death : MonoBehaviour
{
    public float sphereRadius;
    public float maxDistance;

    private Vector3 origin;
    private Vector3 direction;
    
    public void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance))
        {
            //death
            //play animation
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(origin, sphereRadius);
    }
}

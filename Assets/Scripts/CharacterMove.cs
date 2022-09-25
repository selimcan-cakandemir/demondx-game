using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMove : MonoBehaviour
{
    [SerializeReference]
    private float moveSpeed = 4f;
    private Vector3 forward, right;
    private BoxCollider bc;
    private Bounds b;
    public GameObject platform;

    private void Start()
    {
        bc = platform.GetComponent<BoxCollider>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        if (Input.anyKey)
            Move();
    }   

    void Move()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, bc.bounds.min.x, bc.bounds.max.x);
        pos.z = Mathf.Clamp(pos.z, bc.bounds.min.z, bc.bounds.max.z);
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        //transform.forward = heading;
        pos += rightMovement;
        pos += upMovement;
        transform.position = pos;
    }
}

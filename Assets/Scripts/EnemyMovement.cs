using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    public float speed = 1f;
    public ParticleSystem blood;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, 0f, 0.7f);
        transform.position = pos;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target, Vector3.up);
    }

    private void OnDestroy()
    {
        ParticleSystem ps = Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(ps.gameObject, 0.5f);
    }
}

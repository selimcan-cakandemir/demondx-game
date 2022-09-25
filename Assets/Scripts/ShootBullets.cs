using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShootBullets : MonoBehaviour
{
    [Range(0f, 10f)]
    public float radius;
    public float drainAmount;
    public float fillAmount;
    public Image fillComponent;
    public Slider slider;
    private Transform player;
    private LineRenderer lr;
    private Color defaultBarColor;
    
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        player = GameObject.Find("Player").transform;
        defaultBarColor = new Color(0.4f, 0.03f, 1f, 1f);
    }
    
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            EraseLaser();
            //Find closest enemy and kill it
            Transform enemy = NearestEnemy();
            Vector3 origin = transform.position;
            float dist = Vector3.Distance(enemy.position, origin);
            bool isInside = dist < radius;
            if (isInside && slider.value > 5 )
            {
                slider.value -= drainAmount * Time.deltaTime;
                transform.LookAt(enemy, Vector3.up);
                DrawLaser();
                Destroy(enemy.gameObject);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            EraseLaser();
        }
        slider.value += fillAmount * Time.deltaTime;
        if (slider.value > slider.maxValue/2)
        {
            fillComponent.color = defaultBarColor;
        }
        else if (slider.value < slider.maxValue/2)
        {
            fillComponent.color = Color.yellow;
        }
        else
        {
            
        }
    }
    
    void DrawLaser()
    {
        Transform enemy = NearestEnemy();
        lr.SetPosition(0, player.position);
        lr.SetPosition(1, enemy.position);
    }

    void EraseLaser()
    {
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, Vector3.zero);
    }
    
    public Transform NearestEnemy()
    {
        Transform nearEnemy = null;
        float minDist = Mathf.Infinity;
        Vector3 pos = transform.position;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float distBetween = Vector3.Distance(enemy.transform.position, pos);
            if (distBetween < minDist)
            {
                nearEnemy = enemy.transform;
                minDist = distBetween;
            }
        }
        return nearEnemy;
    }

    void OnDrawGizmos()
    {
        // Transform enemy = NearestEnemy();
        // Vector3 origin = transform.position;
        // float dist = Vector3.Distance(enemy.position, origin);
        // bool isInside = dist < radius;
        // Handles.color = isInside ? Color.red : Color.green;
        // Handles.DrawWireDisc(origin, Vector3.up, radius);
    }
}

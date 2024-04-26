using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 6;

    void Awake()
    {
        Vector3 Look = transform.InverseTransformPoint(Player.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, Angle);
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }
    void OnCollisionStay2D(Collision2D collision2D)
    {
        Destroy(gameObject);
    }
}

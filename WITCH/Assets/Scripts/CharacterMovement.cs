using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 20f;
    public float JumpHeight = 20f;
    public Rigidbody2D Body;
    public BoxCollider2D Checker;
    public ContactFilter2D ContactFilter;
    public bool InAir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            Vector2 CurrentSpeed = Body.velocity;
            CurrentSpeed.x = Speed;
            Body.velocity = CurrentSpeed;
        }

        if (Input.GetKey("a"))
        {
            Vector2 CurrentSpeed = Body.velocity;
            CurrentSpeed.x = -Speed;
            Body.velocity = CurrentSpeed;
        }
    }
    void Update()
    {
        ContactPoint2D[] Hits = new ContactPoint2D[1];
        if (Input.GetKeyDown("w") && BodyGrounded())
        {
            Body.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            InAir = true;
        }
        else if (Input.GetKeyDown("w") && CheckerGrounded())
        {
            Body.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            InAir = true;
        }
        else
        {
            InAir = true;
        }
    }

    private void OnCollisionEnter2D()
    {
        if (BodyGrounded())
        {
            InAir = false;
        }
    }

    private bool BodyGrounded()
    {
        Collider2D[] hits = new Collider2D[1];
        return Body.GetContacts(ContactFilter, hits) > 0;
    }
    private bool CheckerGrounded()
    {
        Collider2D[] hits = new Collider2D[1];
        return Checker.GetContacts(ContactFilter, hits) > 0;
    }
}
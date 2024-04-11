using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Player variables for movement. Allow movement to be modify which will be used later on when making gear.
    public float Speed = 20;
    public float JumpHeight = 20;
    public float WallJumpHeight = 20;
    public float WallCling = 0.25f;
    
    // Timers. CoyoteTimer is used for Coyote Time (A short grace period where you can still jump after walking off a platform) and JumpCooldown is used to prevent unintended double jumping.
    private float CoyoteTimer = 0.25f;
    private float JumpCooldown = 0f;
    private float MovingCooldown = 0f;
    
    // References used for player movement and checks.
    public Rigidbody2D Body;
    public PhysicsMaterial2D PlayerPhysics;
    public BoxCollider2D GroundChecker;
    public BoxCollider2D LeftWallChecker;
    public BoxCollider2D RightWallChecker;
    public ContactFilter2D ContactFilter;

    void FixedUpdate()
    {
        if (Input.GetKey("d") && MovingCooldown < 0)
        {
            Vector2 CurrentSpeed = Body.velocity;
            CurrentSpeed.x = Speed;
            Body.velocity = CurrentSpeed;
        }

        if (Input.GetKey("a") && MovingCooldown < 0)
        {
            Vector2 CurrentSpeed = Body.velocity;
            CurrentSpeed.x = -Speed;
            Body.velocity = CurrentSpeed;
        }
    }
    void Update()
    {
        if (Grounded())
        {
            CoyoteTimer = 0.25f;
        }
        else
        {
            CoyoteTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown("w") && CanJump())
        {
            if (Grounded())
            {
                Body.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
                JumpCooldown = 0.25f;
            }
            else if (TouchingLeftWall())
            {
                VelocityReset();
                Body.AddForce((Vector2.up + Vector2.right) * WallJumpHeight, ForceMode2D.Impulse);
                JumpCooldown = 0.25f;
                MovingCooldown = 0.25f;
            }
            else if (TouchingRightWall())
            {
                VelocityReset();
                Body.AddForce((Vector2.up + Vector2.left) * WallJumpHeight, ForceMode2D.Impulse);
                JumpCooldown = 0.25f;
                MovingCooldown = 0.25f;
            }
            else if (CoyoteTimer > 0)
            {
                VelocityReset();
                Body.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
                JumpCooldown = 0.25f;
            }
        }

        JumpCooldown -= Time.deltaTime;
        MovingCooldown -= Time.deltaTime;

        if (!Grounded() && Body.velocity.y >= -1 && (TouchingLeftWall() || TouchingRightWall()))
        {
            PlayerPhysics.friction = 0;
            Body.gravityScale = 4;
        }
        else if (!Grounded() && Body.velocity.y <= -1 && (TouchingLeftWall() || TouchingRightWall()))
        {
            VelocityReset();
            PlayerPhysics.friction = 0;
            Body.gravityScale = WallCling;
        }
        else
        {
            PlayerPhysics.friction = 200;
            Body.gravityScale = 2;
        }

    }
    private bool Grounded()
    {
        Collider2D[] Hits = new Collider2D[1];
        return GroundChecker.GetContacts(ContactFilter, Hits) > 0;
    }
    private bool TouchingLeftWall()
    {
        Collider2D[] Hits = new Collider2D[1];
        return LeftWallChecker.GetContacts(ContactFilter, Hits) > 0;
    }
    private bool TouchingRightWall()
    {
        Collider2D[] Hits = new Collider2D[1];
        return RightWallChecker.GetContacts(ContactFilter, Hits) > 0;
    }
    private bool CanJump()
    {
        return JumpCooldown < 0;
    }

    void VelocityReset()
    {
        var Velocity = Body.velocity;
        Velocity.y = 0;
        Body.velocity = Velocity;
    }
}
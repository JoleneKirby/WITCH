using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    public GameObject Bullet;
    public int Health = 2;
    public float Speed = 2;
    private float WaitPeriod = 3;
    private FlyStates CurrentState;
    private bool PointFound = false;
    private Vector2 Target;
    private RaycastHit2D Hit;
    private Ray2D Ray;
    private enum FlyStates
    {
        Flying,
        Shooting,
        Dead
    }

    void Awake()
    {
        WaitPeriod = 3;
        PointFound = false;
        CurrentState = FlyStates.Flying;
    }

    void FixedUpdate()
    {
        if (Health <= 0)
        {
            CurrentState = FlyStates.Dead;
        }

        switch (CurrentState)
        {
            case FlyStates.Flying:
                WaitPeriod -= Time.deltaTime;
                if (WaitPeriod < 0)
                {
                    if (PointFound == false)
                    {
                        int X = Random.Range(-1, 2);
                        int Y = Random.Range(-1, 2);
                        Hit = Physics2D.Raycast(transform.position, new Vector2(X, Y), 4, 8);
                        Ray = new Ray2D(transform.position, new Vector2(X, Y));
                        while (Hit.collider != null || Y == 0 && X == 0)
                        {
                            X = Random.Range(-1, 2);
                            Y = Random.Range(-1, 2);
                            Hit = Physics2D.Raycast(transform.position, new Vector2(X, Y), 4, 8);
                            Ray = new Ray2D(transform.position, new Vector2(X, Y));
                        }
                        Target = Ray.GetPoint(4);
                        PointFound = true;
                    }
                    transform.position = Vector2.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, Target) <= 0)
                    {
                        WaitPeriod = 2;
                        CurrentState = FlyStates.Shooting;
                    }
                }
                break;

            case FlyStates.Shooting:

                WaitPeriod -= Time.deltaTime;
                if (WaitPeriod < 0)
                {
                    GameObject Clone = Instantiate(Bullet, transform.position, new Quaternion(0, 0, 0, 0));
                    Clone.SetActive(true);
                    PointFound = false;
                    WaitPeriod = 2;
                    CurrentState = FlyStates.Flying;
                }
                break;

            case FlyStates.Dead:

                gameObject.SetActive(false);
                transform.position = new Vector2(100, 100);
                break;
        }
    }
}

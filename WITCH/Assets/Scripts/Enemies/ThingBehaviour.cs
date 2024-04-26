using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ThingBehaviour : MonoBehaviour
{
    public GameObject Player;
    public int Health = 3;
    public float Speed = 1;
    private ThingStates CurrentState;
    private enum ThingStates
    {
        Chasing,
        Dead
    }

    void FixedUpdate()
    {
        switch (CurrentState)
        {
            case ThingStates.Chasing:

                Vector2 Target = Player.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
                break;
                
            case ThingStates.Dead:

                gameObject.SetActive(false);
                transform.position = new Vector2(100, 100);
                break;
        }
    }
}

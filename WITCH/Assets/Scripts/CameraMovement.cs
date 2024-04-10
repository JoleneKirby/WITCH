using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public Camera Cam;
    public float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PlayerPos = Player.position;
        var mousePos = Input.mousePosition;
        Vector2 Mouse = Cam.ScreenToWorldPoint(mousePos);
        Vector2 camTarget = Vector2.Lerp(Player.position, Mouse, 0.5f);
        Vector2 TargetPosition = Vector2.MoveTowards(transform.position, camTarget, Speed * Time.deltaTime);
        transform.position = new Vector3(TargetPosition.x, TargetPosition.y, transform.position.z);
    }
}

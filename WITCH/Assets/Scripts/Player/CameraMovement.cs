using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public Camera Cam;
    public float Speed = 1;
    public Transform Crosshair;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Crosshair.position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PlayerPos = Player.position;
        var MousePos = Input.mousePosition;
        Vector2 Mouse = Cam.ScreenToWorldPoint(MousePos);
        Vector2 CamTarget = Vector2.Lerp(Player.position, Mouse, 0.25f);
        Vector2 TargetPosition = Vector2.MoveTowards(transform.position, CamTarget, Speed * Time.deltaTime);
        transform.position = new Vector3(TargetPosition.x, TargetPosition.y, transform.position.z);
        Crosshair.position = new Vector2(Mouse.x, Mouse.y);
    }
}

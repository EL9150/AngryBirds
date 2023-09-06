using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] strips; // the two strips will be displayed using linerenderer
    public Transform[] strip_positions; 
    public Transform center_position; // center of the slingshot
    public Transform idle_position; // idle position of the strips
    
    public Birds birds = null;
    public BombBird Bomb_bird = null;

    void Start()
    {   
        // 2 points for each strip
        // first point: default strip position on the slingshot
        // second point: mouse position (this position will change when user drag the bird)
        // both strips share the same second point
        strips[0].positionCount = 2;
        strips[1].positionCount = 2;
        strips[0].SetPosition(0, strip_positions[0].position); // first point of strip 0
        strips[1].SetPosition(0, strip_positions[1].position); // first point of strip 1
    }

    // set the second point of the two strips (they share the same second point)
    void Set_Strip_Position(Vector3 position) 
    {
        strips[0].SetPosition(1, position);
        strips[1].SetPosition(1, position);
    }

    // reset the strip positions to idle state
    void Reset_Strip_Position()
    {
        Set_Strip_Position(idle_position.position);
    }

    void Update()
    {   
        if( (birds && birds.isDraggingBird) || (Bomb_bird && Bomb_bird.isDraggingBird)) // player is dragging the bird (hold mouse down)
        {   
            
            Vector3 mouse_position = Input.mousePosition;
            mouse_position.z = 5;
            mouse_position = Camera.main.ScreenToWorldPoint(mouse_position);
            Set_Strip_Position(mouse_position);
            //Debug.Log("1");
            
        }
        else 
        {
            Reset_Strip_Position();
        }
    }
}

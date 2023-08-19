using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    // bird becomes blue when the player clicks on it.
    public void OnMouseDown() 
    {
        GetComponent<SpriteRenderer> ().color = Color.blue; 
    }

    // bird is back to normal when player releases the mouse.
    public void OnMouseUp() 
    {
        GetComponent<SpriteRenderer> ().color = Color.white;
    }

    // Drag the bird
    public void OnMouseDrag() 
    {
        Vector3 Destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Destination.x, Destination.y);
    }

}

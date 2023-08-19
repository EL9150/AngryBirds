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

}

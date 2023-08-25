using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{   
    // destroy the enemy when it gets hit by a bird, or hit by a crate from the top
    void OnCollisionEnter2D(Collision2D target) 
    {
        if (target.collider.GetComponent<Birds> ()) 
        {
            Destroy(gameObject); // hit by bird
        }
        else if (target.GetContact(0).normal.y < 0) 
        {
            Destroy(gameObject); // hit by crates from the top
        }
    }
}

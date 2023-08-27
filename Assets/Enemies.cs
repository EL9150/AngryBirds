using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{   
    public GameObject Destroyed_Effect; // an explosion effect that gets triggered when a monster die

    // destroy the enemy when it gets hit by a bird, or by a crate from the top
    void OnCollisionEnter2D(Collision2D target) 
    {
        if (target.collider.GetComponent<Birds> ()) 
        {   
            // trigger the explosion effect at where the collision occurs (no rotation)
            // then destroy the monster object
            Instantiate(Destroyed_Effect, transform.position, Quaternion.identity);
            Destroy(gameObject); // hit by bird
        }
        else if (target.GetContact(0).normal.y < 0.5) 
        {   
            Instantiate(Destroyed_Effect, transform.position, Quaternion.identity);
            Destroy(gameObject); // hit by crates from the top
        }
    }
}

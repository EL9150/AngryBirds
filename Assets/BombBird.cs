using UnityEngine;
using UnityEngine.SceneManagement;

public class BombBird : Birds
{
    public float exp_radius; //explosion radius
    public float exp_force; //explosion force
    public LayerMask layer_hit; // the layer that got hit by the explosion

    public bool isExploded = false;

    // bombbird will explose when it hits an object
    protected void OnCollisionEnter2D(Collision2D bombbird) 
    {   
        if (!isExploded)
        {
            if (bombbird.collider.CompareTag("Enemy") || bombbird.collider.CompareTag("Crates"))
            {
                explode();
            }
        }
    }

    // explode the bombbird
    protected void explode()
    {   
        isExploded = true; 
        // find all object inside the explosion area
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, exp_radius, layer_hit);
        foreach(Collider2D collider in colliders) 
        {   
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject);
            }
            else 
            {
                // direction of the crate flying
                Vector2 direction = collider.transform.position - transform.position;
                collider.GetComponent<Rigidbody2D>().AddForce(exp_force * direction); // this force will push crates hit by the explosion
            }
        }
    }

    override protected void Update()
    {
        // update idle time
        if ( (is_shot && GetComponent<Rigidbody2D>().velocity.magnitude < 0.1) || isExploded) 
        {
            idle_time += Time.deltaTime;
        }
        // 1. out of the map 
        // 2. bird is idle for too long after getting shot
        // 3. bird is exploded
        if (transform.position.x > 25 
            || transform.position.x < -10 
            || transform.position.y < -20
            || transform.position.y > 10
            || idle_time >= 2.0) 
        {
            SceneManager.LoadScene(scene_name);
        }
    }

    // used to display the explosion area
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, exp_radius);
    }
}

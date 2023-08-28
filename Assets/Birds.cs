using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birds : MonoBehaviour
{

    public Vector3 init_position; // bird's initial position
    public Vector2 slingshot_force; // the greater the force, the faster the bird gets when the player releases the mouse button
    public int bird_speed = 460;
    public string scene_name;
    private bool is_shot = false; // used to check if the bird is shot
    private float idle_time = 0; // time of the bird being idle (stop at the same position) after being shot by the player

    // Player clicks on the bird.
    public void OnMouseDown() 
    {   
        if (!is_shot)
        {
            GetComponent<SpriteRenderer> ().color = Color.blue; // bird is highlighted in blue
        }
    }

    // Player releases the mouse button.
    public void OnMouseUp() 
    {
        if (!is_shot)
        {
            GetComponent<SpriteRenderer> ().color = Color.white; // bird's color is back to normal
            GetComponent<Rigidbody2D> ().gravityScale = 1; // birds are affected by gravity after the player releases the mouse button
            slingshot_force = init_position - transform.position; // dragging the bird to the left will shoot the bird to the right
            GetComponent<Rigidbody2D> ().AddForce(slingshot_force * bird_speed); // shoot the bird
            is_shot = true;
        }
    }

    // Drag the bird.
    public void OnMouseDrag() 
    {
        if (!is_shot)
        {
            Vector3 MouseDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(MouseDestination.x, MouseDestination.y);
        }
    }

    // initialize the bird's initial position
    public void Awake()
    {
        init_position = transform.position;
    }

    /* game will restart if the bird is out of the map or when the bird is idle 
    for too long after being shot */
    void Update()
    {
        // update idle time
        if (is_shot && GetComponent<Rigidbody2D>().velocity.magnitude < 0.1) 
        {
            idle_time += Time.deltaTime;
        }
        // 1. out of the map 
        // 2. bird is idle for too long after getting shot
        if (transform.position.x > 25 
            || transform.position.x < -10 
            || transform.position.y < -20
            || transform.position.y > 10
            || idle_time >= 2.0) 
        {
            SceneManager.LoadScene(scene_name);
        }
    }
}

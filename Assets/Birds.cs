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

    // Player clicks on the bird.
    public void OnMouseDown() 
    {
        GetComponent<SpriteRenderer> ().color = Color.blue; // bird is highlighted in blue
    }

    // Player releases the mouse button.
    public void OnMouseUp() 
    {
        GetComponent<SpriteRenderer> ().color = Color.white; // bird's color is back to normal
        GetComponent<Rigidbody2D> ().gravityScale = 1; // birds are affected by gravity after the player releases the mouse button
        slingshot_force = init_position - transform.position; // dragging the bird to the left will shoot the bird to the right
        GetComponent<Rigidbody2D> ().AddForce(slingshot_force * bird_speed); // shoot the bird
    }

    // Drag the bird.
    public void OnMouseDrag() 
    {
        Vector3 MouseDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(MouseDestination.x, MouseDestination.y);
    }

    // initialize the bird's initial position
    public void Awake()
    {
        init_position = transform.position;
    }

    void Update()
    {
        if (transform.position.x > 13.7 || transform.position.x < -13 || transform.position.y < -7 || transform.position.y > 7) 
        {
            SceneManager.LoadScene(scene_name);
        }
    }
}

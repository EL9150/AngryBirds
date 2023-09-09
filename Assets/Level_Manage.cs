using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manage : MonoBehaviour
{
    private Enemies[] all_enemies; // an array of monsters in the scene
    public string next_scene; // next scene to load after all monsters in the current scene are destroyed

    private void OnEnable()
    {
        all_enemies = FindObjectsOfType<Enemies>();
    }

    private void Update()
    {
        foreach(Enemies enemy in all_enemies)
        {
            if (enemy) 
            {
                return; // nothing happens if at least one monster is still alive
            }
        }
        //Debug.Log("All monsters destroyed. Time to load the next level.");

        // all monsters have been eliminated, load the next scene
        SceneManager.LoadScene(next_scene);
    }

    // return to mainmenu
    public void home_button()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

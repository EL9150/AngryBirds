using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    // jump to load_this_scene
    public void NewGame_button(string load_this_scene)
    {
        SceneManager.LoadScene(load_this_scene);
    }

    // exit the game
    public void Exit_button()
    {
        Application.Quit();
    }
}

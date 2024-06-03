using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }

    public void StartTutorialButton()
    {
        SceneManager.LoadScene(1);
    }

    public void StartEasyLevelButton()
    {
        SceneManager.LoadScene(2);
    }

    public void StartNormalLevelButton()
    {
        SceneManager.LoadScene(3);
    }

    public void StartHardLevelButton()
    {
        SceneManager.LoadScene(4);
    }
}

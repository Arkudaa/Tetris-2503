using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }


    public void GoNext()
    {
        SceneManager.LoadScene(2);
    }
}

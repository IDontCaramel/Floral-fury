using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void OnButtonClick()
    {
        Scene Current_Scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(Current_Scene.name);
        Time.timeScale = 1;
    }
}

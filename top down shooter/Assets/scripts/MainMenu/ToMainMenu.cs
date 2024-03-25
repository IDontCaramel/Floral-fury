using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToMainMenu : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;
    }
}
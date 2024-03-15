using UnityEngine;
using UnityEngine.SceneManagement;
public class ToMainMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
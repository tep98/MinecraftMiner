using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("MainScene");
    }
}

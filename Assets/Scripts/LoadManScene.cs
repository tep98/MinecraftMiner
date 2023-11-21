using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainScene", 2f);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}

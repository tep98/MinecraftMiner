using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void StartAdBanner();

    [DllImport("__Internal")]
    private static extern void StartGame();
    private void Start()
    {
        StartGame();
        InvokeRepeating("ShowAdBanner", 0, 60);
    }

    private void ShowAdBanner()
    {
        StartAdBanner();
        Time.timeScale = 0;
        //music.volume = 0f;
    }
    
    public void OffPause()
    {
        Time.timeScale = 1f;
        //music.volume = 1f;
    }
}

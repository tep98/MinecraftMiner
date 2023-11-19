using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void StartAdBanner();
    private void Start()
    {
        InvokeRepeating("ShowAdBanner", 10, 60);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices; 

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();

    public string currentLanguage; //ru en

    public static Language Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            currentLanguage = GetLang();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

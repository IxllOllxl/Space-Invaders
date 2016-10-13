using System;
using UnityEngine;

public class Config : MonoBehaviour 
{
    public static bool IsPaused = false;

    void Awake()
    {
        IsPaused = false;
    }
}
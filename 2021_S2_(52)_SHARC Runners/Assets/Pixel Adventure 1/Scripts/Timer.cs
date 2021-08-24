using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class Timer : MonoBehaviour
{
    private static System.Timers.Timer currentTime;

    // Update is called once per frame
    public void SetTimer(int n)
    {
        Console.WriteLine("Started time");
        Console.ReadLine();
        currentTime = new System.Timers.Timer(n);
        currentTime.AutoReset = true;
        currentTime.Enabled = true;
        Console.WriteLine("ended time");
        Console.ReadLine();
    }

    public void StopTimer()
    {
        //currentTime.Stop;
        //currentTime.Dispose;

    }
}

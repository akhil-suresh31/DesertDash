using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public static int MinCount;
    public static int SecCount;
    public static float MilliCount;
    public static string MillieDisplay;
    public static bool updtime = false;

    public GameObject MilliBox;
    public GameObject SecondBox;
    public GameObject MinuteBox;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        updtime = true;
        MilliBox.GetComponent<Text>().text = "0";
        SecondBox.GetComponent<Text>().text = "00.";
        MinuteBox.GetComponent<Text>().text = "00:";
    }

    void Update()
    {
        if(updtime)
            MilliCount += Time.deltaTime * 10;
        MillieDisplay = MilliCount.ToString("F0");
        MilliBox.GetComponent<Text>().text = "" + MillieDisplay;

        if(MilliCount>9)
        {
            SecCount++;
            MilliCount = 0;
        }

        if(SecCount<10)
            SecondBox.GetComponent<Text>().text = "0" + SecCount + ".";
        else
            SecondBox.GetComponent<Text>().text = "" + SecCount + ".";

        if (SecCount ==60)
        {
            MinCount++;
            SecCount = 0;
        }

        MinuteBox.GetComponent<Text>().text = "0" + MinCount + ":";
    }
}

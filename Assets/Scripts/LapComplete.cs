using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public int NoOfLaps;
    void Start()
    {
        NoOfLaps = 1;
    }
    public GameObject lapCPannel;
    public GameObject LapCompleteTrig;
    public GameObject HalflapTrig;
    public GameObject LapCounter;
    public GameObject MilliDisplay;
    public GameObject SecondDisplay;
    public GameObject MinuteDisplay;
    public GameObject BestTimeDisp;
    public GameObject finishPanel;
    
    public GameObject pausebutton;
    public GameObject Timerpanel;
    void OnTriggerExit()
    {
        NoOfLaps++;
        
        int Sec = LapTimeManager.SecCount;
        int Min= LapTimeManager.MinCount;
        int Mil;
        Int32.TryParse(LapTimeManager.MillieDisplay,out Mil);
        print("Entered finish line");

        int oldsec,oldmil,oldmin;
        print("Current time= "+Min + ":" + Sec + "." + Mil);
        //print(oldmil);
        if (NoOfLaps>2)
        {
            Int32.TryParse(SecondDisplay.GetComponent<Text>().text, out oldsec);
            Int32.TryParse(MinuteDisplay.GetComponent<Text>().text, out oldmin); 
            Int32.TryParse(MilliDisplay.GetComponent<Text>().text, out oldmil); 
            print("oldtime = " + oldmin + ":" + oldsec + "." + oldmil);
            if (oldmin<=Min)
                if (oldsec < Sec || (oldsec == Sec && oldmil < Mil)) 
                   {
                        Sec = oldsec;
                        Min = oldmin;
                        Mil = oldmil;
                    } 
                

        }
        print(Min + ":" + Sec + "." + Mil);
        if(LapTimeManager.SecCount<10)
            SecondDisplay.GetComponent<Text>().text = "0" + Sec ;
        else
            SecondDisplay.GetComponent<Text>().text = "" + Sec ;

        MinuteDisplay.GetComponent<Text>().text = "0" + Min;

        MilliDisplay.GetComponent<Text>().text = "" + Mil;
        LapCounter.GetComponent<Text>().text = "" + NoOfLaps + "/2";
        LapTimeManager.SecCount = 0;
        LapTimeManager.MilliCount = 0;
        LapTimeManager.MinCount = 0;
        if (NoOfLaps == 3)
        {
            CarController.braked = true;
            finishPanel.SetActive(true);
            LapTimeManager.updtime = false;
            
            pausebutton.SetActive(false);
            BestTimeDisp.GetComponent<Text>().text = "Best Time :" + MinuteDisplay.GetComponent<Text>().text + ":" + SecondDisplay.GetComponent<Text>().text + "." + MilliDisplay.GetComponent<Text>().text;
            Debug.Log(MinuteDisplay.GetComponent<Text>().text +":"+ SecondDisplay.GetComponent<Text>().text +":"+ MilliDisplay.GetComponent<Text>().text);
            lapCPannel.SetActive(false);
            
            Timerpanel.SetActive(false);
        }
        HalflapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    

    }
}

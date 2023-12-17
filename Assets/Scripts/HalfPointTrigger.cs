using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HalfTrigger;
    public GameObject LapCompleteTrigger;

    void OnTriggerExit()
    {
        print("Enter half trigger");
       
        HalfTrigger.SetActive(false);
        LapCompleteTrigger.SetActive(true);
    }
    
}

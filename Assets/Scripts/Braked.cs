using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Braked : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public static void ApplyBrake()
    {
        CarController.reverse = true;
        print("Brake");
        CarController.braked = true;
        
    }
    public static void ReleaseBrake()
    {
        CarController.braked = false;
        CarController.reverse = false;
      
    }
}

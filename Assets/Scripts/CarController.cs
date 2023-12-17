using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FDTGloveUltraCSharpWrapper;
using System.Runtime.InteropServices;
using UnityEngine.EventSystems;
public class CarController : MonoBehaviour
{
    public Button Brake;
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;
    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;
    public Vector3 eulertest;
    public static bool braked = false;
    public static bool reverse = false;
    private float maxBrakeTorque = 20000;
    private Rigidbody rb;
    public Transform centreofmass;
    private float maxTorque = 1900;
    private CfdGlove GloveRight,GloveLeft;
    private float[] RHSVal, LHSVal;
    [DllImport("fglove.dll")]
    public static extern int Needed(int x);
    void Start()
    {
     
        RHSVal = new float[13];
        LHSVal = new float[13];
        GloveLeft = new CfdGlove();
        GloveRight = new CfdGlove();
        GloveRight.Open("USB0");
        GloveLeft.Open("USB1");
        braked = false;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GloveRight.GetSensorScaledAll(ref RHSVal);
        GloveLeft.GetSensorScaledAll(ref LHSVal);
    }

    void FixedUpdate()
    {
        if (reverse)
        {
            braked = false;
            WheelRR.motorTorque = maxTorque * -2;
            WheelRL.motorTorque = maxTorque * -2;
            // braked = false;
        }
        else
        { 
            WheelRR.motorTorque = maxTorque * 1;
            WheelRL.motorTorque = maxTorque * 1;
        }
        //changing car direction
        // Here we are changing the steer angle of the front tyres of the car so that we can change the car direction.
        
        WheelFL.steerAngle = 50 * (RHSVal[0] - LHSVal[0]);
        WheelFR.steerAngle = 50 * (RHSVal[0] - LHSVal[0]);
        /*WheelFL.steerAngle = 40 * Input.acceleration.x;
        WheelFR.steerAngle = 40 * Input.acceleration.x;*/



    }
    void Update()
    {
        GloveRight.GetSensorScaledAll(ref RHSVal);
        GloveLeft.GetSensorScaledAll(ref LHSVal);

        if (((RHSVal[3] + RHSVal[6] + RHSVal[9] + RHSVal[12]) / 4 > 0.5) && ((LHSVal[3] + LHSVal[6] + LHSVal[9] + LHSVal[12]) / 4 > 0.5))
            Braked.ApplyBrake();
        
        if (((RHSVal[3] + RHSVal[6] + RHSVal[9] + RHSVal[12]) / 4 < 0.5) && ((LHSVal[3] + LHSVal[6] + LHSVal[9] + LHSVal[12]) / 4 < 0.5))
            Braked.ReleaseBrake();
          
        HandBrake();
            
        if (!braked)
        {
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
            WheelRL.brakeTorque = 0;
            WheelRR.brakeTorque = 0;
        }
        
        
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LapTimeManager.MilliCount = 0;
            LapTimeManager.SecCount = 0;
            LapTimeManager.MinCount = 0;
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }    
        //for tyre rotate
        WheelFLtrans.Rotate(WheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelFRtrans.Rotate(WheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRLtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRRtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //changing tyre direction
        Vector3 temp = WheelFLtrans.localEulerAngles;
        Vector3 temp1 = WheelFRtrans.localEulerAngles;
        temp.y = WheelFL.steerAngle - (WheelFLtrans.localEulerAngles.z);
        WheelFLtrans.localEulerAngles = temp;
        temp1.y = WheelFR.steerAngle - WheelFRtrans.localEulerAngles.z;
        WheelFRtrans.localEulerAngles = temp1;
        eulertest = WheelFLtrans.localEulerAngles;
        

    }
    void HandBrake()
    {
        //Debug.Log("brakes " + braked);
        /*if (Input.touchCount ==1)
        {
            braked = true;
        }
        else
        {
            braked = false;
        }*/
        if (braked)
        {
            //WheelFL.brakeTorque = maxBrakeTorque * 200;
            //WheelFR.brakeTorque = maxBrakeTorque * 200;
            WheelRL.brakeTorque = maxBrakeTorque * 200;//0000;
            WheelRR.brakeTorque = maxBrakeTorque * 200;//0000;
            WheelRL.motorTorque = 0;
            WheelRR.motorTorque = 0;
            //reverse = true;
        }
        //braked = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DriveCar : MonoBehaviour
{
    TaxiStationUI taxiStationUI;
    public Image fuelBarProgress,repairBarProgress;
    public Rigidbody rb;
    public WheelCollider frontRightWheel, frontLeftWheel, backRightWheel, backLeftWheel;
    float engineSpeed,turnSpeed,brakeSpeed = 150000, minSpeed;
    public float movingEnginesSpeed,normalSpeed;
    public float movingTurnsSpeed;
    [SerializeField] float lowEngineSpeed = 50;
    [SerializeField] float lowTurnSpeed = 10;
    [SerializeField] float minFuel = 0.20f;
    public FloatingJoystick joystick;
    public GameObject frontLeftWheelGO,frontRightWheelGO,speedoMeter;
    Vector3 frontLeftW, frontRightW;
    private AudioSource audioSource;
    public float minPitch, maxPitch, pitchFromCar;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        taxiStationUI = GetComponent<TaxiStationUI>();
    }

    void FixedUpdate()
    {
        EngineSound();
        CarSpeed();
        WheelRotation();
        CarControl();
        StartSpeed();
    }

    void CarControl()
    {
        if (repairBarProgress.fillAmount > minFuel)
        {
            if (fuelBarProgress.fillAmount != 0)
            {
                if ((joystick.Vertical != 0 || joystick.Horizontal != 0) && !taxiStationUI.isEnable)
                {
                    EngineSpeedFuel();
                }
                else
                {
                    BrakeControl();
                }
            }
        }
        else
        {
            if (fuelBarProgress.fillAmount != 0)
            {
                if ((joystick.Vertical != 0 || joystick.Horizontal != 0) && !taxiStationUI.isEnable)
                {
                    EngineSpeedNoFuel();
                }
                else
                {
                    BrakeControl();
                }
            }
        }
        if (fuelBarProgress.fillAmount == 0)
        {
            if ((joystick.Vertical != 0 || joystick.Horizontal != 0) && !taxiStationUI.isEnable)
            {
                EngineSpeedNoFuel();
            }
            else
            {
                BrakeControl();
            }
        }
    }

    void EngineSpeedFuel()
    {
        engineSpeed = movingEnginesSpeed;
        turnSpeed = movingTurnsSpeed;
        fuelBarProgress.fillAmount -= Time.deltaTime / 200;
        backRightWheel.motorTorque = engineSpeed * joystick.Vertical;
        backLeftWheel.motorTorque = engineSpeed * joystick.Vertical;
        frontRightWheel.steerAngle = turnSpeed * joystick.Horizontal;
        frontLeftWheel.steerAngle = turnSpeed * joystick.Horizontal;
        backRightWheel.brakeTorque = 0;
        backLeftWheel.brakeTorque = 0;
        frontLeftWheel.brakeTorque = 0;
        frontRightWheel.brakeTorque = 0;
    }
    void EngineSpeedNoFuel()
    {
        fuelBarProgress.fillAmount -= Time.deltaTime / 200;
        engineSpeed = lowEngineSpeed;
        turnSpeed = lowTurnSpeed;
        backRightWheel.motorTorque = engineSpeed * joystick.Vertical;
        backLeftWheel.motorTorque = engineSpeed * joystick.Vertical;
        frontRightWheel.steerAngle = turnSpeed * joystick.Horizontal;
        frontLeftWheel.steerAngle = turnSpeed * joystick.Horizontal;
        backRightWheel.brakeTorque = 0;
        backLeftWheel.brakeTorque = 0;
        frontLeftWheel.brakeTorque = 0;
        frontRightWheel.brakeTorque = 0;
    }
    void BrakeControl()
    {
        engineSpeed = 0;
        turnSpeed = 0;
        frontLeftWheel.brakeTorque = brakeSpeed;
        frontRightWheel.brakeTorque = brakeSpeed;
        backRightWheel.brakeTorque = brakeSpeed;
        backLeftWheel.brakeTorque = brakeSpeed;
    }
    void WheelRotation()
    {
        frontLeftW = frontLeftWheelGO.transform.localEulerAngles;
        frontLeftW.y = frontLeftWheel.steerAngle;
        frontLeftWheelGO.transform.localEulerAngles = frontLeftW;

        frontRightW = frontRightWheelGO.transform.localEulerAngles;
        frontRightW.y = frontRightWheel.steerAngle;
        frontRightWheelGO.transform.localEulerAngles = frontRightW;
    }
    void EngineSound()
    {
        pitchFromCar = speedoMeter.GetComponent<Speedometer>().speed / 70f;


        if (speedoMeter.GetComponent<Speedometer>().speed < minSpeed)
        {
            audioSource.pitch = minPitch;
        }
        if (speedoMeter.GetComponent<Speedometer>().speed > minSpeed && speedoMeter.GetComponent<Speedometer>().speed < speedoMeter.GetComponent<Speedometer>().speedMax)
        {
            audioSource.pitch = minPitch + pitchFromCar;
        }
        if (speedoMeter.GetComponent<Speedometer>().speed > speedoMeter.GetComponent<Speedometer>().speedMax)
        {
            audioSource.pitch = maxPitch;
        }
    }
    public float CarSpeed()
    {
        speedoMeter.GetComponent<Speedometer>().speed = rb.velocity.magnitude;
        speedoMeter.GetComponent<Speedometer>().speed *= 3.6f;
        if (speedoMeter.GetComponent<Speedometer>().speed > speedoMeter.GetComponent<Speedometer>().speedMax)
        {
            rb.velocity = (speedoMeter.GetComponent<Speedometer>().speedMax / 3.6f) * rb.velocity.normalized;
        }
        return speedoMeter.GetComponent<Speedometer>().speed;
    }

    public void StartSpeed()
    {
      if(speedoMeter.GetComponent<Speedometer>().speed <= 20)
        {
            movingEnginesSpeed = 420;
            movingTurnsSpeed = 55;
        }
        else
        {
            movingEnginesSpeed = normalSpeed;
            movingTurnsSpeed = 45;
        }
    }
        
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public Vector3 distance;
    public float lookUp;

    private GameObject ballObject;

    public float lerpAmount;
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        ballObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate() 
    {
        transform.position = Vector3.Lerp(transform.position, ballObject.transform.position + distance, lerpAmount + Time.deltaTime);
        transform.LookAt(ballObject.transform.position);
        transform.Rotate(-lookUp, 0, 0);
        
    }
}

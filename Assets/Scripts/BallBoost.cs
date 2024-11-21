using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
[RequireComponent(typeof(Rigidbody))]

public class BallBoost : MonoBehaviour
{

    [SerializeField]
    float boostForce = 1f;

    GameObject boostText;
    Rigidbody rb;
    bool boostActivated = false;
    bool boostReady = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostText = GameObject.Find("Boost Text").gameObject;
        TextVisible();
    }

    void Update()
    {
        TextVisible();

        if (Input.GetKeyDown(KeyCode.Space) && boostReady && rb.velocity != Vector3.zero)
        {
            boostActivated = true;
            boostReady = false;
            StartCoroutine("BoostCoroutine");
        }
        
    }

    private void FixedUpdate()
    {
        if (boostActivated)
        {
            rb.AddForce(rb.velocity.normalized * boostForce, ForceMode.Impulse);
            boostActivated = false;
        }
    }

    IEnumerator BoostCoroutine()
    {
        yield return new WaitForSeconds(3f);
        boostReady = true;
        yield break;
    }
       private void TextVisible()
    {
        if (boostReady)
        {
            boostText.SetActive(true);
        }
        else
        {
           boostText.SetActive(false);
        }
    }
}

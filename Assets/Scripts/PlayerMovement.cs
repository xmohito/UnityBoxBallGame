using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    bool isRigidbody;
    private Rigidbody rb;

    private GameManager gameManager;

    public float maxAngularVelocity;

private void Update() 
{
    if (transform.position.y <= -10f)
    {
        gameManager.RestartLevel();
    }
}
    private void Start()
    {
        if (isRigidbody = TryGetComponent<Rigidbody>(out rb))
        {
            rb.maxAngularVelocity = maxAngularVelocity;
        }
        //gameManager = FindObjectOfType<GameManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    } 


private void FixedUpdate()
 {
        float Hdirection;
        if (isRigidbody && (Hdirection = Input.GetAxis("Horizontal")) != 0)
        {
            rb.AddTorque(0,0, -Hdirection * speed * Time.fixedDeltaTime);
        }


        float Vdirection;
        if (isRigidbody && (Vdirection = Input.GetAxis("Vertical")) != 0)
        {
            rb.AddTorque(Vdirection * speed * Time.fixedDeltaTime, 0,0);
        }
}
 } 
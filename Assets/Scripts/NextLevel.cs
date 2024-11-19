using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
    gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
   private void OnTriggerEnter(Collider other) 
   {
    if(other.CompareTag("Player")){
        gm.NextLevel();
    }
    
   }
}

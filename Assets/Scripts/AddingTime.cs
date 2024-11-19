using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AddingTime : MonoBehaviour
{

    public float timeToAdd;
    public GameObject bonusParticles;
    SoundManager soundManager;

    GameManager gm;
    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }
   private void OnTriggerEnter(Collider other) {
         if(other.CompareTag("Player"))
         {
            soundManager.PlaySound(SoundManager.Sounds.Bonus); 
            gm.time += timeToAdd;
            Instantiate(bonusParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
         }
   }
}

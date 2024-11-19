using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 [Header("Ball Settings")]
    public GameObject ballPrefab;
    public Transform  startPosition;
 [Header("Time Settings")]
    public TextMeshProUGUI timeText;
    public float time;
    public float slowTimeSeconds;
    public float slowTimeAmount;

    AudioSource audioSource;
    SoundManager soundManager;
    private void Awake() {
               Instantiate(ballPrefab, startPosition.position, Quaternion.identity);
    }
    void Start()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.Clamp(Mathf.CeilToInt(time), 0, int.MaxValue).ToString();

        if(time <= 0)
        {
           RestartLevel();
        }

        if(Time.timeScale >= 1f && time <= slowTimeSeconds) //slow time
        {
            Time.timeScale = slowTimeAmount;
            timeText.enableVertexGradient = false;
            timeText.color = new Color(1f, 0.2f, 0.2f);
            audioSource.Play();
        }
        else if (Time.timeScale < 1f && time > slowTimeSeconds)//normal time
        {
            Time.timeScale = 1f;
            timeText.enableVertexGradient = true;
            timeText.color = new Color(1f, 1f, 1f);
            audioSource.Stop();
        }

    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        soundManager.PlaySound(SoundManager.Sounds.Lose);
    }

    public void NextLevel()
    {
        soundManager.PlaySound(SoundManager.Sounds.Win);
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        else
            SceneManager.LoadScene(0);
    }
}

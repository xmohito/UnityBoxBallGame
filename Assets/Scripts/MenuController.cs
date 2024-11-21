using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void LoadLevel(int index)
    {
        Application.Quit();
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {   
        Application.Quit();
    }
}

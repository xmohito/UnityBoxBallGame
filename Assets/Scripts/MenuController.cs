using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void SceneChanger0(){
        SceneManager.LoadScene(0);
    }

    public void SceneChanger1(){
        SceneManager.LoadScene(1);
    }

    public void AppExit(){
        Application.Quit();    
    }
}

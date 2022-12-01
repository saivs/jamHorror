using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    public void ChangeScene(){
        SceneManager.LoadScene("Game");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}

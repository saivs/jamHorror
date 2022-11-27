using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoToExit(){
        SceneManager.LoadScene("Menu");
    }

    public void GoToRestart(){
        SceneManager.LoadScene("Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

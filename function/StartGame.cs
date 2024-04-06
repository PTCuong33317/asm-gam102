using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOn(){
        SceneManager.LoadScene("AutoMap");
    }
    public void ReStart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void QuitGame(){
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameWinUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        gameWinUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        //Application.LoadLevel(Application.loadedLevel);
    }
}

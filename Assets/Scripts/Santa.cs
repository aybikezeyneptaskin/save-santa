using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Santa : MonoBehaviour
{
    //public WinScreen WinScreen;
    //public GameObject canvas;
    //public GameObject gameWinUI;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {   
       canvas = GameObject.FindGameObjectWithTag("canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           gameWon();
        }
    }

    void gameWon(){
        //WinScreen.Setup();
        //canvas.GetComponent<Canvas>().enabled = true;
        Win();
        Debug.Log("WON!!!!!!!!!");
    }

    public void Win()
    {   
        canvas.SetActive(true);
        //gameWinUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        //Application.LoadLevel(Application.loadedLevel);
    }*/
}

    
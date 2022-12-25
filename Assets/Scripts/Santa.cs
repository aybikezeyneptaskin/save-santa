using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    //public WinScreen WinScreen;
    //public GameObject canvas;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           gameWon();
        }
    }

    void gameWon(){
        //WinScreen.Setup();
        //canvas.GetComponent<Canvas>().enabled = true;
        gameManager.Win();
        Debug.Log("WON!!!!!!!!!");
    }
}

    
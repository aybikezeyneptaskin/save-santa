using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public GameObject winmenu;

    public void Setup(){
        Debug.Log("canvas");
        //winmenu.SetActive(true);
    }
    public void PlayAgainButton(){
        Debug.Log("canvas2");
        //winmenu.SetActive(false);
        //SceneManager.LoadScene("SampleScene");
    }
}

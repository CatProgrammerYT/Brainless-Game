using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void Settings()
    {
        Debug.Log("Working!!!");
    }
    public void Quit()
    {
        Application.Quit();
    }

}

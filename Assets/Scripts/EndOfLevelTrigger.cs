using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelTrigger : MonoBehaviour
{   
    private GameObject finalTrigger;

    private void Start()
    {

        finalTrigger = this.gameObject;

        if (finalTrigger.GetComponent<BoxCollider>() == null)
        {
            Debug.LogError("There is no box collider in this cube! >:(");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
            if(Application.loadedLevel + 1 > SceneManager.sceneCountInBuildSettings)
            {
                Application.Quit();
            }
        }
    }
}

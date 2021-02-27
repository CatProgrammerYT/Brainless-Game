using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{

    public KeyCode restartKeyCode = KeyCode.R;
    private Camera MainCamera;

    private void Start()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(restartKeyCode)) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}

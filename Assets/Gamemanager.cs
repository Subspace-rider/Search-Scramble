using UnityEngine;
using UnityEngine.InputSystem;
//using System;
using TMPro;

public class Gamemanager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current == null) return;

        if(Gamepad.current == null) return;

    }
}

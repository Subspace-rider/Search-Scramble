using UnityEngine;
using UnityEngine.InputSystem;
//using System;
using TMPro;
using Unity.VisualScripting;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] public GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;
    
    private bool keyboardJoined = false;
    private bool controllerJoined = false;

    void Update()
    {
        if(Keyboard.current == null) return;

        if(!keyboardJoined && Keyboard.current.rightShiftKey.wasPressedThisFrame)
        {
            var player = PlayerInput.Instantiate(playerPrefab,
                controlScheme: "Keyboard&Mouse",
                pairWithDevice: Keyboard.current);
            
            if(spawnPoints.Length > 0)
            {
                player.transform.position = spawnPoints[0].position;
            }
            keyboardJoined = true;
        }

        if(Gamepad.current == null) return;

        foreach (var gamePad in Gamepad.all)
        {
            if(gamePad.rightStickButton.wasPressedThisFrame && !controllerJoined)
            {
                PlayerInput.Instantiate(playerPrefab,
                    controlScheme:"Gamepad",
                    pairWithDevice: gamePad);
                
                controllerJoined = true;
            }
        }
    }
}

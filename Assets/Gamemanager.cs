using UnityEngine;
using UnityEngine.InputSystem;
//using System;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public List<GameObject> Players;
    [SerializeField] public GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;
    public TextMeshProUGUI startTimerText;
    public float startTime = 10f;
    public TextMeshProUGUI gameTimerText;
    public float gameTimer = 40f;
    
    private bool keyboardJoined = false;
    private bool controllerJoined = false;

    void Start()
    {
        //startTimerText.SetActive(false);
        //gameTimerText.SetActive(false);
    }
    public void OnStartGame(InputValue value)
    {
        if(value.isPressed)
        {
            //startTimerText.SetActive(true);
            startTimerText.text = "Run: " + startTime.ToString("0.00");
            if(startTime > 0)
            {
                startTime -= Time.deltaTime;
            }
            if(startTime <= 0)
            {
                
            }
        }
    }
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
            Players.Add(player.gameObject);
            player.gameObject.layer = LayerMask.NameToLayer("Player "+ Players.Count);
        }

        if(Gamepad.current == null) return;

        foreach (var gamePad in Gamepad.all)
        {
            if(gamePad.rightStickButton.wasPressedThisFrame && !controllerJoined)
            {
                var player = PlayerInput.Instantiate(playerPrefab,
                    controlScheme:"Gamepad",
                    pairWithDevice: gamePad);
                
                controllerJoined = true;
                Players.Add(player.gameObject);
                player.gameObject.layer = LayerMask.NameToLayer("Player "+ Players.Count);
            }
        }

        startTimerText.text = "Run: " + startTime.ToString("0.00");

        if(startTime <= 0)
        {
            gameTimerText.text = "Remaining Time: " + gameTimer.ToString("0.00");
        }


        if(gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }

        if(gameTimer <= 0)
        {
            //SceneManager.LoadScene("");
        }
    }
}

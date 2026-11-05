using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System;
public class playerscript : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private SpriteRenderer playerSprite;
    [SerializeField]public float moveSpeed = 5f;
    private Vector2 moveInput;
    public bool pickedHider;
    public bool pickedHunter;
    //public int hiderCount = 0;
    //public int hunterCount = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerRB = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        playerRB.linearVelocity = moveInput * moveSpeed;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current == null) return;

        if(Gamepad.current == null) return;

        if(Keyboard.current.rKey.wasPressedThisFrame || Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            pickedHider = true;
            pickedHunter = false;
        }
        if(Keyboard.current.hKey.wasPressedThisFrame || Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            pickedHunter = true;
            pickedHider = false;
        }

        if(pickedHider == true && pickedHunter == false)
        {
            playerSprite.color = Color.dimGray;
        }
        
        if(pickedHunter == true && pickedHider == false)
        {
            playerSprite.color = Color.darkRed;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System;
public class playerscript : MonoBehaviour
{
    public enum PlayerState
    {
        NULL,
        HUNTER,
        HIDER
    }
    public PlayerState mystate;
    private Rigidbody2D playerRB;
    private SpriteRenderer playerSprite;
    [SerializeField]public float moveSpeed = 5f;
    private Vector2 moveInput;
    
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
    public void SwitchState()
    {
        
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
    }
}

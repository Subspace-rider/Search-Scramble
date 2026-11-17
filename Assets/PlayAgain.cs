using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnReplay(InputValue value)
    {
        if(value.isPressed)
        {
            SceneManager.LoadScene("Search-Scramble");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

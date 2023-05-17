using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    private GameManager gameManager;
    
    public float delta = 0.15f;
    public float speed = 6.0f;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        startPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Stop moving if the game is over
        if (gameManager.isGameActive)
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin (Time.time * speed);
            transform.position = v;
        }        
    }
}

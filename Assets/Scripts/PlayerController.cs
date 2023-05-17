using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject ballPrefab;

    private float horizontalInput;
    private float speed = 8.0f;
    private float xRange = 1.95f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Check for left and right bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Player movement left to right
        if (gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        
            if (Input.GetKeyDown(KeyCode.Space) && gameManager.balls > 0 && (-xRange <= transform.position.x) &&  (transform.position.x <= xRange))
            {
                // Drop a ball
                Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
            
                // Subtract 1 from the count of balls remaining
                gameManager.UpdateBalls();
            }
        }        
    }
}

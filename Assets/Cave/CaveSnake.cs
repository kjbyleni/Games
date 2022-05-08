using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveSnake : MonoBehaviour
{
    private bool isGameOver;
    private Rigidbody2D rigidBody;
    private Vector3 deadPosition;
    // Start is called before the first frame update
    void Start()
    {
        deadPosition = new Vector3();
        isGameOver = false;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.LogError("up arrow pushed");
                rigidBody.AddForce(new Vector2(0, 100));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.LogError("up arrow pushed");
                rigidBody.AddForce(new Vector2(0, -100));
            }
            transform.position = new Vector3(transform.position.x + .0125f, transform.position.y, 0);
        }
        else
        {
            transform.position = deadPosition;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Border")
        {
            rigidBody.gravityScale = 0;
            deadPosition = transform.position;
            isGameOver = true;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public TextMesh score;
    public GameObject tryAgain;
    public List<GameObject> enemies;
    public float speedStep;
    public float initialSpeed;
    public Collider2D boardCollider;
    private float moveSpeed;
    private Vector2 _direction = Vector2.up;
    private int foodCount = 0;

    public void Start()
    {
        GenerateRandomEnemy();
        tryAgain.SetActive(false);
        moveSpeed = initialSpeed + speedStep;

    }

    void GenerateRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Count);
        Instantiate(enemies[enemyIndex]);
    }

    //User input to adjust the direction snake is moving
    void CheckDirectionChange()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
    }

    //Moves the snake depending on direction input
    void MoveSnake()
    {
        transform.position = new Vector3(
            transform.position.x + _direction.x * moveSpeed,
            transform.position.y + _direction.y * moveSpeed,
            transform.position.z
            );
    }

    // Update is called once per frame
    void Update()
    {
        if(moveSpeed == 0 && !tryAgain.activeSelf)
        {
            tryAgain.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        CheckDirectionChange();
    }

    private void FixedUpdate()
    {
        MoveSnake();
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Food")
        {
            foodCount += 1;
            score.text = foodCount.ToString();

            if (foodCount % 2 == 0)
            {
                moveSpeed = initialSpeed + (foodCount * speedStep);

            }
            Destroy(col.gameObject);
            GenerateRandomEnemy();

        }

        if(col.gameObject.tag == "Border")
        {
            moveSpeed = 0;
            Debug.LogError("Game Over!");
        }


    }

}

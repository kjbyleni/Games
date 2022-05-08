using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speedStep;
    public float initialSpeed;
    protected float moveSpeed;
    protected Vector3 fixedPosition;


    void Start()//Initialize in random place within the bounds of grass object
    {
        Vector3 bounds = GameObject.FindWithTag("Grass").GetComponent<BoxCollider2D>().bounds.size;
        float xCenter = bounds.x / 2;
        float yCenter = bounds.y / 2;
        float xPos = Random.Range(-xCenter, xCenter);
        float yPos = Random.Range(-yCenter, yCenter);
        fixedPosition = new Vector3(xPos, yPos, -2);
        Debug.Log(fixedPosition);
        moveSpeed = initialSpeed + speedStep;

    }

}

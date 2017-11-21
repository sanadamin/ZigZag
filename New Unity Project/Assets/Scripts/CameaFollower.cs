using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameaFollower : MonoBehaviour
{
    public GameObject ball;
    [SerializeField]
    private float lerpRate;
    public bool gameOver;

    private Vector3 offset;
    
    // Use this for initialization
    void Start()
    {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 position = transform.position;
        Vector3 targetPosition = ball.transform.position - offset;
        position = Vector3.Lerp(position, targetPosition, lerpRate * Time.deltaTime);
        transform.position = position;
    }
}

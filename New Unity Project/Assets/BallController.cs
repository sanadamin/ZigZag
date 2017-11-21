using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    private float speed = 1f;
    private Rigidbody rigidBody;
    private bool firstTouchEnable = false;
    private bool ballKnockedOut = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0) && !firstTouchEnable)
        {
            firstTouchEnable = true;
            rigidBody.velocity = new Vector3(speed, 0f, 0f);
        }else if (Input.GetMouseButtonDown(0) && !ballKnockedOut)
        {
            SwitchDirection();
        }
      if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            ballKnockedOut = true;
            rigidBody.velocity = new Vector3(0f, -30f, 0f);
            Invoke("DestroyBall", 3f);
        }
	}
    void DestroyBall()
    {
        Destroy(gameObject);
    }
    void SwitchDirection()
    {
        if(rigidBody.velocity.z > 0)
        {
            rigidBody.velocity = new Vector3(speed, 0f, 0f);
        }else if(rigidBody.velocity.x > 0)
        {
            rigidBody.velocity = new Vector3(0f, 0f, speed);
        }
    }
}

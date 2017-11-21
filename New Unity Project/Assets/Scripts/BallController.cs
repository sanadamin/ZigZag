using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    private float speed = 1f;
    public ParticleSystem particles;
    public AudioClip coin;
   


    private Rigidbody rigidBody;
    private bool firstTouchEnable = false;
    private bool ballKnockedOut = false;
    private CameaFollower mainCamera;
    private PlatFormSpawner platFormSpawner;
    private AudioSource audioSource;

    private void Awake()
    {
        
        rigidBody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        
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
            mainCamera = GameObject.FindObjectOfType<CameaFollower>();
            mainCamera.gameOver = true;
            platFormSpawner = GameObject.FindObjectOfType<PlatFormSpawner>();
            platFormSpawner.gameOver = true;
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
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag ==  "Diamond")
        {
           
            Instantiate(particles, collider.gameObject.transform.position, Quaternion.identity);
            audioSource.clip = coin;
            audioSource.Play();
            Destroy(collider.gameObject);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {


    private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<BallController>()) {
            Invoke("PlatformRemoval", 0.5f);
            Invoke("DestroyPlatform", 3f);
        }
    }
    void PlatformRemoval()
    {
        rigidBody.velocity = new Vector3(0f, -10f, 0f);
        rigidBody.isKinematic = false;
    }
    void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}

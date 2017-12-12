using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    //create boolean variables to limit movements
	public float movementSpeed = 10;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
        {
			gameObject.transform.Translate (-movementSpeed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.D))
        {
			gameObject.transform.Translate (movementSpeed * Time.deltaTime, 0, 0);
		}
        if (Input.GetKey(KeyCode.Alpha1))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }


    }
}

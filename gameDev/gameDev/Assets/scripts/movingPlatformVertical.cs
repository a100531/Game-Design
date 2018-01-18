using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformVertical : MonoBehaviour {
	public float move = 4;
	public float speed = 10;
	private float initialPosition ;
	public bool up = false;
	public bool down = false;
	// Use this for initialization
	void Start () {
		//takes the initial position of the object on y axis
		initialPosition = gameObject.transform.position.y;
		Debug.Log(initialPosition);
	}
	
	// Update is called once per frame
	void Update () {
		if(up){
			gameObject.transform.Translate(0,speed*Time.deltaTime,0);
			if(transform.position.y >= initialPosition + move){
				speed = 0;
			}

		}
			
	 	else if(down){
			gameObject.transform.Translate(0,-speed*Time.deltaTime,0);
			if(transform.position.y <= initialPosition - move){
				speed = 0;
			}

		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			Debug.Log("interact");
			down = true;
		}
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

	public float move = 4;
	public float speed = 10;
	private float initialPosition ;
	public bool left = false;
	public bool right = false;
	// Use this for initialization
	void Start () {
		initialPosition = gameObject.transform.position.x;
		Debug.Log(initialPosition);
	}
	
	// Update is called once per frame
	void Update () {

		
		
		if(right){
			gameObject.transform.Translate(speed*Time.deltaTime,0,0);
			if(transform.position.x >= initialPosition + move){
				speed = 0;
			}

		}
			
	 	else if(left){
			gameObject.transform.Translate(-speed*Time.deltaTime,0,0);
			if(transform.position.x <= initialPosition - move){
				speed = 0;
			}

		}
		

		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlexhalfMove : MonoBehaviour {
public float move = 4;
	public float speed = 10;
	private float initialPositionL ;
	
	public bool left = false;
	
	public GameObject leftDoor;
	

	
	
	private Player player;
	// Use this for initialization
	void Start () {
		
		initialPositionL = leftDoor.transform.position.x;
		Debug.Log(initialPositionL);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(left)
		{
			leftDoor.transform.Translate(-speed*Time.deltaTime,0,0);
			if(leftDoor.transform.position.x <= initialPositionL - move)
			{
				speed = 0;
			}
		}
	}
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player" && Player.isEarth)
		{	
			
			left = true;

		}
	}
}

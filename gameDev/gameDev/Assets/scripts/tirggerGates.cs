using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirggerGates : MonoBehaviour {
	public float move = 4;
	public float speed = 10;
	private float initialPositionL ;
	private float initialPositionR ;
	public bool left = false;
	public bool right = false;
	public GameObject leftDoor;
	public GameObject rightDoor;

	public bool openGate = false;
	
	private Player player;
	// Use this for initialization
	void Start () {
		
		initialPositionL = leftDoor.transform.position.x;
		Debug.Log(initialPositionL);
		initialPositionR = rightDoor.transform.position.x;
		Debug.Log(initialPositionR);
	}
	
	// Update is called once per frame
	void Update () {
		if(right)
		{
			rightDoor.transform.Translate(speed*Time.deltaTime,0,0);
			if(rightDoor.transform.position.x >= initialPositionR + move)
			{
				speed = 0;
			}
		}
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
			right = true;
			left = true;

		}
	}
}

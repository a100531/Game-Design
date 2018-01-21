using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour {

	public float move = 4;
	public float speed = 10;
	private float initialPositionL ;
	
	public bool right = false;
	
	public GameObject Stone;
	

	
	
	private Player player;
	// Use this for initialization
	void Start () {
		
		initialPositionL = Stone.transform.position.x;
		Debug.Log(initialPositionL);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(right)
		{
			Stone.transform.Translate(speed*Time.deltaTime,0,0);
			//Stone.transform.Rotate(0,0,speed*Time.deltaTime);
			if(Stone.transform.position.x >= initialPositionL + move)
			{
				speed = 0;
			}
		}
	}
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player" && Player.isEarth)
		{	
			
			right = true;

		}
	}
}

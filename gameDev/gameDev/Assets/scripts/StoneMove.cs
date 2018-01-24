using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour {

	public float move = 4;
	public float speed = 10;
	public float stoneSpeed = 30;
	private float initialPositionL ;
	
	public bool right = false;
	
	public GameObject Stone;
	public GameObject stoneSprite;
	

	
	
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
			stoneSprite.transform.Rotate(0,0,-stoneSpeed*Time.deltaTime);
			if(Stone.transform.position.x >= initialPositionL + move)
			{
				speed = 0;
				stoneSpeed = 0;
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

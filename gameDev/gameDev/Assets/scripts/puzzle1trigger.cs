using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle1trigger : MonoBehaviour {
	public float move = 4;
	public float speed = 10;
	private float initialPosition ;

	//public bool up = false;
	//public bool down = false;
	private bool moveUp = false;
	private bool moveDown = false; 

	public GameObject wall;
	public GameObject wall2;
	public GameObject wall3;
	public GameObject trigger2;
	public GameObject trigger3;
	// Use this for initialization
	void Start () {
		initialPosition = wall.transform.position.y;
		Debug.Log(initialPosition + "wall");
		trigger2.SetActive(false);
		trigger3.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(moveUp){
			wall.transform.Translate(0,+speed*Time.deltaTime,0);
			
			if(wall.transform.position.y >= initialPosition + move)
			{
				speed = 0;
			}
			
		//if(moveDown){
			
			wall2.transform.Translate(0,-speed*Time.deltaTime,0);
			wall3.transform.Translate(0,-speed*Time.deltaTime,0);
			if(wall2.transform.position.y <= initialPosition - move)
			{
				speed = 0;
			}
			if(wall3.transform.position.y <= initialPosition - move)
			{
				speed = 0;
			}
		//}
		}		
	}
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player" && Player.isEarth)
		{
			moveUp = true;
			//moveDown = true;
			trigger2.SetActive(true);
			trigger3.SetActive(true);
		}
	
	}
}

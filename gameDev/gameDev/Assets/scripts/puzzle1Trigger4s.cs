using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle1Trigger4s : MonoBehaviour {

	public float move = 4;
	public float speed = 10;
	private float initialPosition ;

	public bool up = false;
	public bool down = false;
	private bool moveUp = false;
	private bool moveDown = false; 
	public GameObject trigger2;
	public GameObject trigger3;
	public GameObject trigger4;
	public GameObject wall;
	// Use this for initialization
	void Start () {
		initialPosition = wall.transform.position.y;
		Debug.Log(initialPosition + "wall");
	}
	
	// Update is called once per frame
	void Update () {
		if(moveUp){
			wall.transform.Translate(0,speed*Time.deltaTime,0);
			if(wall.transform.position.y >= initialPosition + move)
			{
				speed = 0;
			}
		}
		if(moveDown){
			wall.transform.Translate(0,-speed*Time.deltaTime,0);
			if(wall.transform.position.y <= initialPosition - move)
			{
				speed = 0;
			}
		}		
	}
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player" && Player.isEarth && up)
		{
			moveUp = true;
			trigger2.SetActive(false);
			trigger3.SetActive(false);
			trigger4.SetActive(false);
		}
		if (c.tag == "Player" && Player.isEarth && down)
		{
			moveDown = true;
			trigger2.SetActive(false);
			trigger3.SetActive(false);
			trigger4.SetActive(false);
		}
	}
}

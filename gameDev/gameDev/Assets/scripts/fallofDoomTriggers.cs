using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallofDoomTriggers : MonoBehaviour {
	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject platform4;
	public GameObject platform5;
	public GameObject platform6;
	public GameObject platform7;
	public GameObject platform8;
	public GameObject platform9;
	public GameObject platform10;
	public GameObject platform11;
	public GameObject platform12;
	public GameObject platform13;
	public GameObject platform14;
	public GameObject platform15;
	public GameObject platform16;
	public GameObject platform17;
	public GameObject platform18;
	public GameObject platform19;
	public GameObject platform20;

	// Use this for initialization
	void Start () {
		platform1.SetActive(false);
		platform2.SetActive(false);
		platform3.SetActive(false);
		platform4.SetActive(false);
		platform5.SetActive(false);
		platform6.SetActive(false);
		platform7.SetActive(false);
		platform8.SetActive(false);
		platform9.SetActive(false);
		platform10.SetActive(false);
		platform11.SetActive(false);
		platform12.SetActive(false);
		platform13.SetActive(false);
		platform14.SetActive(false);
		platform15.SetActive(false);
		platform16.SetActive(false);
		platform17.SetActive(false);
		platform18.SetActive(false);
		platform19.SetActive(true);
		platform20.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c) {
		if(c.tag == "Player" && Player.isEarth){
			platform1.SetActive(true);
			platform2.SetActive(true);
			platform3.SetActive(true);
			platform4.SetActive(true);
			platform5.SetActive(true);
			platform6.SetActive(true);
			platform7.SetActive(true);
			platform8.SetActive(true);
			platform9.SetActive(true);
			platform10.SetActive(true);
			platform11.SetActive(true);
			platform12.SetActive(true);
			platform13.SetActive(true);
			platform14.SetActive(true);
			platform15.SetActive(true);
			platform16.SetActive(true);
			platform17.SetActive(true);
			platform18.SetActive(true);
			platform19.SetActive(false);
			platform20.SetActive(false);
		}
	}
}

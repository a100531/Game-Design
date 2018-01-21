using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPlatforms : MonoBehaviour {

	public GameObject platform;
	// Use this for initialization
	void Start () {
		platform.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
			
	}
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player" && Player.isEarth)
		{
			platform.SetActive(true);	
		}
	}
}

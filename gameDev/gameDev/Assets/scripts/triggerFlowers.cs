using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFlowers : MonoBehaviour {
	public GameObject flower;
	// Use this for initialization
	void Start () {
		flower.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player" && Player.isEarth)
		{	
			flower.SetActive(true);

		}
	}
}

﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject player;
	private GameObject currentPlayer;
	private GameCamera cam;
	private Vector3 checkpoint;

	void Start () {
		cam = GetComponent<GameCamera> ();
		cam.SetTarget (GameObject.FindGameObjectWithTag("Player").transform);
		//if(GameObject.FindGameObjectWithTag("Spawn"))
		//{
		//	checkpoint = GameObject.FindGameObjectWithTag("Spawn").transform.position;
		//}

		//SpawnPlayer (checkpoint);
	//}
	
	//private void SpawnPlayer(Vector3 spawnPos) {
		//currentPlayer = Instantiate(player,spawnPos,Quaternion.identity) as GameObject;
		//cam.SetTarget (GameObject.FindGameObjectWithTag("Player").transform);
	}

	//private void Update () {
	//		if(!currentPlayer)
	//		{
	//			if (Input.GetKey(KeyCode.R))
	//			{
	//			SpawnPlayer (checkpoint);
	//			}
	//		}
	//}

	//public void SetCheckpoint(Vector3 cp) {
	//	checkpoint = cp;
	//}

	public void EndLevel () {
	
		}

}

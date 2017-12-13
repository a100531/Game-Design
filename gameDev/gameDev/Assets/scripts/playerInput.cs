using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour {

	private CharacterController characterController;
	public bool isGrounded;
	public float gravity;
	public float jumpSpeed;
	public float moveSpeed;
	private float fallSpeed;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		gameObject.GetComponent<Renderer>().material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		IsGrounded();
		Fall();
		Jump();
		Move();	

		if (Input.GetKey(KeyCode.Alpha1))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
	
	}
	void Move(){
		float xSpeed = Input.GetAxis("Horizontal");
		if(xSpeed != 0) characterController.Move(new Vector3(xSpeed, 0) * moveSpeed * Time.deltaTime);
	}
	void Jump(){
		if(Input.GetButtonDown ("Jump") && isGrounded){
			fallSpeed = -jumpSpeed;
		}
	}
	void Fall(){
		if(!isGrounded){
			fallSpeed += gravity * Time.deltaTime;
		}
		else{
			if(fallSpeed > 0) fallSpeed = 0;
		}
		characterController.Move(new Vector3(0, -fallSpeed) * Time.deltaTime);
	}
	void IsGrounded(){
		isGrounded = (Physics.Raycast(transform.position, -transform.up, characterController.height/1.8f));
	}

}

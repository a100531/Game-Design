using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerInput : MonoBehaviour {

	private CharacterController characterController;
	public bool isGrounded;
	public float gravity;
	public float jumpSpeed;
	public float moveSpeed;
	private float fallSpeed;
	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject platform4;
	public GameObject platform5;
	public GameObject platform6;
	public GameObject platform7;
	public GameObject platform8;
	public GameObject platform9;
	public GameObject switch5;
	public GameObject switch8;

	public bool jumpAir;
	public bool isEarth = false;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		gameObject.GetComponent<Renderer>().material.color = Color.blue;
		jumpAir = true;
		platform1.SetActive(false);
		platform2.SetActive(false);
		platform3.SetActive(false);
		platform4.SetActive(false);
		platform7.SetActive(false);
		platform8.SetActive(false);
		switch8.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetKey(KeyCode.Alpha1))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
			jumpAir = true;
			isEarth = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
			jumpAir = false;
			isEarth = true;
        }
		IsGrounded();
		Fall();
		Jump();
		Move();	
	
	}
	void Move(){
		float xSpeed = Input.GetAxis("Horizontal");
		if(xSpeed != 0) characterController.Move(new Vector3(xSpeed, 0) * moveSpeed * Time.deltaTime);
	}
	void Jump(){
		if(Input.GetButtonDown ("Jump") && isGrounded && jumpAir){
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

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "box" && isEarth){
			Debug.Log("interact");
			platform1.SetActive(true);
		}
		if(other.tag == "box1" && isEarth){
			Debug.Log("interact");
			platform2.SetActive(true);
			
		}
		if(other.tag == "box2" && isEarth){
			Debug.Log("interact");
			platform3.SetActive(true);
			
		}
		if(other.tag == "box3" && isEarth){
			Debug.Log("interact");
			platform4.SetActive(true);
			platform9.SetActive(false);
			
			
		}
		if(other.tag == "box4" && isEarth){
			Debug.Log("interact");
			platform5.SetActive(false);
			
		}
		if(other.tag == "box5" && isEarth){
			Debug.Log("interact");
			platform6.SetActive(false);
			platform7.SetActive(true);
			platform8.SetActive(true);
			switch8.SetActive(false);
	
		}
		if(other.tag == "box6" && isEarth){
			Debug.Log("interact");
			platform6.SetActive(true);
			platform7.SetActive(false);
	
		}
		if(other.tag == "box7" && isEarth){
			Debug.Log("interact");
			platform6.SetActive(false);
			switch8.SetActive(true);
	
		}
		if(other.tag == "box8" && isEarth){
			Debug.Log("interact");
			platform8.SetActive(false);
			switch5.SetActive(false);
			
	
		}
		if(other.tag == "slope"){
			Debug.Log("slope");
			isGrounded = true;
		}
		
	}
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "deathwall"){
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

}

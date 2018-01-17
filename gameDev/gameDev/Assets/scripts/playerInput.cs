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
	public GameObject air;
    public GameObject earth;

	public GameObject rose1;
	

	public bool jumpAir;
	public bool isEarth = false;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		//gameObject.GetComponent<Renderer>().material.color = Color.blue;
		jumpAir = true;
		rose1.SetActive(false);
		air.SetActive(true);
        earth.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetKey(KeyCode.Alpha1))
        {	
			air.SetActive(true);
            earth.SetActive(false);
            //gameObject.GetComponent<Renderer>().material.color = Color.blue;
			jumpAir = true;
			isEarth = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
			air.SetActive(false);
            earth.SetActive(true);
            //gameObject.GetComponent<Renderer>().material.color = Color.green;
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
		if(other.tag == "flowerTrigger" && isEarth){
			Debug.Log("interact");
			rose1.SetActive(true);
		}
		// use this when slopes start being used
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

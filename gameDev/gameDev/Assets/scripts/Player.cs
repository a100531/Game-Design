using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour {
	//Animator anim;
	public float speed;
	public float jumpHeight;
	public float gravity = 20;
	public float acceleration = 30;
	public GameObject player;
	
	public GameObject platform1;
	private bool jumping;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	private float lastCheckpointX;
	private float lastCheckpointY;

	private PlayerPhysics playerPhysics;
	private GameManager manager;
	public static bool isEarth = false;
	// Use this for initialization
	void Start () {

		playerPhysics = GetComponent<PlayerPhysics>();
		//anim = GetComponent<Animator> ();
		
		platform1.SetActive(false);
		gameObject.GetComponent<Renderer>().material.color = Color.blue;
		manager = Camera.main.GetComponent<GameManager>();


	}

	// Update is called once per frame
	void Update () {
		

		if (playerPhysics.movementstop) 
		{
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		if (Input.GetKey(KeyCode.Alpha1))
        {	
			//air.SetActive(true);
            //earth.SetActive(false);
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
			isEarth = false;
        }
		 if (Input.GetKey(KeyCode.Alpha2))
        {
			//air.SetActive(false);
            //earth.SetActive(true);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
			isEarth = true;
        }

		//anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		
		if (playerPhysics.grounded && !isEarth) {
			amountToMove.y = 0;

			if (jumping) {
				jumping = false;
				//anim.SetBool("Jumping",false);
			}

			if (Input.GetButtonDown("Jump")||Input.GetKeyDown("space")) {
				amountToMove.y = jumpHeight;
				jumping = true;
				//anim.SetBool("Jumping",true);
			}
		}

		
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);

		//Face Direction
		float moveDir = Input.GetAxisRaw ("Horizontal");
		if (moveDir != 0) 
		{
			transform.eulerAngles = (moveDir > 0) ? Vector3.up * 180 : Vector3.zero;
		}
		
	}
	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}
	 	
		

		//hit detections
		void OnTriggerEnter(Collider c) {
		if(c.tag == "checkpoint"){
			
			Debug.Log("Checkpoint Bitch");
			lastCheckpointX = gameObject.transform.position.x;
			Debug.Log(lastCheckpointX);
			lastCheckpointY = gameObject.transform.position.y;
			Debug.Log(lastCheckpointY);
		}
		if(c.tag == "deathwall"){
			Debug.Log("spawned");
			if(lastCheckpointX != 0 && lastCheckpointY != 0){
				transform.position = new Vector3(lastCheckpointX, lastCheckpointY, 0);
			}
			else{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

}		
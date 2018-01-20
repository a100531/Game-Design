using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour {
	//Animator anim;
	public float speed;
	public float jumpHeight;
	public float gravity = 20;
	public float acceleration = 30;
	public GameObject player;
	//float jumpTime, jumpDelay = 0.05f;
	//bool jumped;
	private bool jumping;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	private PlayerPhysics playerPhysics;
	private GameManager manager;
	// Use this for initialization
	void Start () {

		playerPhysics = GetComponent<PlayerPhysics>();
		//anim = GetComponent<Animator> ();
		manager = Camera.main.GetComponent<GameManager>();
		//transform.eulerAngles = Vector3.up * 180;


	}

	// Update is called once per frame
	void Update () {
		

		if (playerPhysics.movementstop) 
		{
			targetSpeed = 0;
			currentSpeed = 0;
		}
		

		//anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		
		if (playerPhysics.grounded) {
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
			// Jump
			//if (Input.GetButtonDown("Jump")) {
			//	amountToMove.y = jumpHeight;
			//	jumpTime = jumpDelay;
			//	anim.SetTrigger("Jump");
			//	jumped = true;
				
				
			//}
			//jumpTime-= Time.deltaTime;
			//if(jumpTime <= 0 && playerPhysics.grounded && jumped)
			//{
			//	anim.SetTrigger ("Land");
			//	jumped = false;
				
			//}
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

		//if (Input.GetKeyDown (KeyCode.Q) && canShoot == true) 
		//{
		//		Throw (Axe);
		//		
		//}
		//if(ammoAxes <= 0){canShoot = false;}
		
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
	 	
		//void Throw(GameObject Axe)

		//{
		//	Instantiate (Axe, gameObject.transform.position, gameObject.transform.rotation);	
		//	ammoAxes--;
		//}
		

		//hit detections
		void OnTriggerEnter(Collider c) {
		if (c.tag == "Checkpoint" )
		{
			manager.SetCheckpoint(c.transform.position);
			Debug.Log("checkpoint");
		}
	}

}		
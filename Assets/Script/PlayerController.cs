using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	private Animator anim;
	bool isJump=false;
	public float timer = 0.5f;
	public GameObject MainCameras;
	public float speed;
	public float jumpSpeed = 1.0F;
	public float gravity = 5.0F;
	public float verticalVelocity;
	CharacterController controller;
	private Vector3 moveDirection;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public const int maxHealth = 150;
	public static int currentHealth = maxHealth; 
	public bool primacurva;
	private bool finish;
	private bool morto;
	private float deathTimer;




	// Use this for initialization
	void Start () {


		moveDirection = new Vector3 (0f, verticalVelocity , speed);
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		controller = rb.GetComponent<CharacterController> ();
		primacurva = false;
		finish = false;
		morto = false;
		deathTimer = 3f;
	}




	void FixedUpdate() {

		if (finish == true) {
		
			moveDirection = new Vector3 (0f, 0f, 0f);
		
		
		}else 
			if (primacurva == true) {

			moveDirection = new Vector3 (speed, verticalVelocity, 0f);		
		
			} else {
				moveDirection = new Vector3 (0f, verticalVelocity, speed);
			}

		if (morto == true) {
			deathTimer -= Time.deltaTime;

			if (deathTimer <= 0) {
				currentHealth = maxHealth;
				Scene active = SceneManager.GetActiveScene ();
				SceneManager.LoadScene (active.name);
				ScoreManager.score = 0;
			}
		}

		anim.SetBool ("Jump", false);
		anim.SetBool ("Shoot", false);
	

		if (controller.isGrounded && finish==false) {
			verticalVelocity = -gravity * Time.deltaTime;



			if (Input.GetKey(KeyCode.Space)) {

				if (isJump == false) {
					verticalVelocity = jumpSpeed;
					anim.Play("Jumping");

				}


			}
		} else {

			verticalVelocity -= gravity * Time.deltaTime;

		}


		controller.Move (moveDirection);

		timer -= Time.deltaTime;
		if (finish == false) {
			
			if (Input.GetAxis ("Horizontal") > 0) {

				if (primacurva == true) {

					controller.Move (new Vector3 (0f, 0f, -0.1f));

				} else {

					controller.Move (new Vector3 (0.1f, 0f, 0f));
				}
			}


			if (Input.GetAxis ("Horizontal") < 0) {

				if (primacurva == true) {
			
					controller.Move (new Vector3 (0f, 0f, 0.1f));
						
				} else {
					
					controller.Move (new Vector3 (-0.1f, 0f, 0f));
				}

			}

			if (Input.GetKeyDown (KeyCode.W) || Input.GetAxis("Vertical") > 0) {

				if (timer <= 0) {
					timer = 0.5f;
					anim.Play ("Shoot");
					Fuoco ();
				}



			}
		}





	}

	void Fuoco(){

		var bullet = (GameObject)Instantiate (

			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);


		if (primacurva == true) {
		
			bullet.GetComponent<Rigidbody> ().AddRelativeForce (50f, 0f, 0f, ForceMode.Impulse);
		
		} else {
		
			bullet.GetComponent<Rigidbody> ().AddRelativeForce (0f, 0f, 50f, ForceMode.Impulse);
		}




		Destroy (bullet, 2.0f);


	}


	void OnCollisionEnter(Collision collision)
	{

		var hit = collision.gameObject;

		if(hit.CompareTag("PlayerDead1")){

			anim.SetBool ("Death", true);
			anim.Play ("Death");
			finish = true;
			morto = true;
		

		}

		if(hit.CompareTag("ActivateEnemy")){

			EnemyShootScript.activate = true;


		}

		if(hit.CompareTag("DeactivateEnemy")){

			EnemyShootScript.activate = false;


		}

		if (hit.CompareTag ("CurvaADX")) {

	
			this.transform.Rotate (new Vector3 (0, 45, 0));
		
			this.transform.position =  new Vector3 (9.08f, -0.74f, 1003.43f);

			primacurva = true;
		
		
		
		}

		if (hit.CompareTag ("Arrivo")) {
		
			finish = true;
			anim.SetBool ("Finish", true);
		
		
		
		}



	
			


	}


public void TakeDamage(int amount) {

		currentHealth -= amount; 

		if (currentHealth <= 0) { 

			currentHealth = 0;

			anim.SetBool ("Death", true);
			anim.Play ("Death");
			finish = true;
			morto = true;



			currentHealth = maxHealth;
		
		}
	}


	public void Restore() {

		currentHealth = maxHealth; 

	}


}

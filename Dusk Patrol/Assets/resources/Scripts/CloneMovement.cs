using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour {

	Stack<Vector2> future_positions, past_positions;

	Stack<bool> future_shots, past_shots;

	public GameObject bullet;

	float timeSinceDeath, timeUntilSpawn;
	int spawnState = 3; //0 -- currently alive; 1 -- not spawned yet; 2 -- dead, but waiting; 3 -- not initialized

	//Carried over from Playermovement so shooting works
	private Vector2 leftGun;
	private Vector2 rightGun;
	private float maxCoolDown = 0.2f; // 1/5th of a second
	private float currCoolDown = 0f;
	private float horizScale = 0.275f; //scale used to get the location of the guns
	private float vertScale = 0.75f;

	// Use this for initialization
	void Start () {
		timeSinceDeath = 0;
		timeUntilSpawn = 0;
		//spawnState = 3;
		//gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		//gameObject.GetComponent<Collider2D> ().enabled = false;
		Debug.Log ("Unbooted");
	}
	
	// Update is called once per frame
	void Update () {
		switch(spawnState) {
		case 0:
			StandardMovement ();
			break;
		case 1:
			//Waiting to spawn
			timeUntilSpawn -= Time.deltaTime * TimeManager.timeFactor;
			if (timeUntilSpawn <= 0) {
				//Respawn!
				respawn ();
			}
			break;
		case 2:
			//Waiting after death, until time travel window passes us by
			timeSinceDeath += Time.deltaTime * TimeManager.timeFactor;
			if (timeSinceDeath >= TimeManager.timeLimit) {
				//Hard despawn
			}
			if (timeSinceDeath <= 0) {
				//Respawn!
				respawn ();
			}
			break;
		default:
			//Do nothing
			break;
		}
	}

	void StandardMovement() {

		if (TimeManager.timeFactor > 0) {
			past_positions.Push (gameObject.transform.position);
			if (future_positions.Count > 0) {
				gameObject.transform.position = future_positions.Pop ();
			} else {
				die ();
			}
			SetGunLocations();
			if (future_shots.Count > 0) {
				bool isFiring = future_shots.Pop ();
				past_shots.Push (isFiring);
				tryShot (isFiring);
			}
		} else if (TimeManager.timeFactor < 0) {
			future_positions.Push (gameObject.transform.position);
			if (past_positions.Count > 0) {
				gameObject.transform.position = past_positions.Pop ();
			} else {
				unspawn ();
			}
			if (past_shots.Count > 0) {
				future_shots.Push (past_shots.Pop ());
			}
		} else {
			//Don't fucking move i swear to the lord
		}
	}

	void tryShot(bool isFiring) {
		if (currCoolDown > maxCoolDown && isFiring)
		{
			
			//shootystuff.Play ();
			GameObject bullet1 = Instantiate(bullet, leftGun, transform.rotation);
			GameObject bullet2 = Instantiate(bullet, rightGun, transform.rotation);

			bullet1.GetComponent<BasicBullet>().setAsPlayerBullet();
			bullet2.GetComponent<BasicBullet>().setAsPlayerBullet();

			currCoolDown = 0f;
		}
		currCoolDown += Time.deltaTime;
	}

	void respawn() {
		spawnState = 0;
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		gameObject.GetComponent<Collider2D> ().enabled = true;
	}

	void unspawn () {
		spawnState = 1;
		timeUntilSpawn = 0;
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<Collider2D> ().enabled = false;
	}

	void die() {
		spawnState = 2;
		timeSinceDeath = 0;
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<Collider2D> ().enabled = false;
	}

	public void startUp(Stack<Vector2> movements, Stack<bool> shots) {
		respawn ();
		future_positions = clone (movements);
		future_shots = clone (shots);
		past_shots = new Stack<bool> ();
		past_positions = new Stack<Vector2> ();
		Debug.Log ("Booted");
	}

	Stack<Vector2> clone(Stack<Vector2> stack) {
		Vector2[] temp = new Vector2[stack.Count];
		stack.CopyTo (temp, 0);
		Stack<Vector2> fin = new Stack<Vector2> ();

		for (int i = temp.Length - 1; i >= 0; i--) {
			fin.Push (temp [i]);
		}

		return fin;

	}

	Stack<bool> clone(Stack<bool> stack) {
		bool[] temp = new bool[stack.Count];
		stack.CopyTo (temp, 0);
		Stack<bool> fin = new Stack<bool> ();

		for (int i = temp.Length - 1; i >= 0; i--) {
			fin.Push (temp [i]);
		}

		return fin;
	}

	void SetGunLocations()
	{
		leftGun = transform.position + horizScale * Vector3.left + vertScale * Vector3.up;
		rightGun = transform.position - horizScale * Vector3.left + vertScale * Vector3.up;
	}
}

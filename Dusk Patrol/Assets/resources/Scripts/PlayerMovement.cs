using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;
	public GameObject clone_prefab;
    public TimeManager tm;
	public AudioSource shootystuff;

    private Rigidbody2D rigidBody;
    private Vector2 leftGun;
    private Vector2 rightGun;

    public float speed = 7f;
    private float maxCoolDown = 0.2f; // 1/5th of a second
    private float currCoolDown = 0f;

    private float horizScale = 0.275f; //scale used to get the location of the guns
    private float vertScale = 0.75f; //scale used to set how far in front of the plane to make the bullets

    private Vector2 currPosition;
	Stack<Vector2> past_positions;
    Stack<Vector2> future_positions;

	Stack<bool> past_shots;
	Stack<bool> future_shots;

	bool goingBack;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SetGunLocations();
		past_positions = new Stack<Vector2> ();
        future_positions = new Stack<Vector2>();
		past_shots = new Stack<bool> ();
		future_shots = new Stack<bool> ();
    }

    private void Start()
    {
        if (tm == null)
        {
            tm = FindObjectOfType<TimeManager>();
        }
		shootystuff.volume = OptionScript.loadSettings ().SFX;
    }

    void Update()
    {
        if (TimeManager.timeFactor > 0)
        {
            MovePlayer();
            Shoot(bullet);
			if (goingBack) {
				SpawnClone ();
				goingBack = false;
			}
        }
        else
        {
			goingBack = true;
            rigidBody.velocity = Vector2.zero;
        }        

		StoreLocation();
        SetGunLocations();
        BackTrack();

		/*if (Input.GetKeyDown (KeyCode.Tab)) {
			SpawnClone ();
		}*/
    }

    void MovePlayer()
    {

		Vector3 mousepos = Input.mousePosition;

		Vector3 mouseviewportpos = Camera.main.ScreenToViewportPoint (mousepos);
		Vector3 mouseworldpoint = Camera.main.ViewportToWorldPoint(new Vector2(Mathf.Max(Mathf.Min(mouseviewportpos.x, 1),0), Mathf.Max(Mathf.Min(mouseviewportpos.y, 1), 0)));
		Vector2 delta = mouseworldpoint - gameObject.transform.position;
		Vector2 movement = delta.normalized * speed * (Mathf.Atan (delta.magnitude));
		gameObject.GetComponent<Rigidbody2D> ().velocity = movement;
        CameraScript.WrapAround(gameObject);
    }

    void Shoot(GameObject bullet)
    {
        if (currCoolDown > maxCoolDown)
        {
            if (Input.GetButton("Fire1"))
            {
				shootystuff.Play ();
                GameObject bullet1 = Instantiate(bullet, leftGun, transform.rotation);
                GameObject bullet2 = Instantiate(bullet, rightGun, transform.rotation);

                bullet1.GetComponent<BasicBullet>().setAsPlayerBullet();
                bullet2.GetComponent<BasicBullet>().setAsPlayerBullet();

            }
            currCoolDown = 0f;
        }
        currCoolDown += Time.deltaTime;
    }

    void BackTrack()
    {
		if (TimeManager.timeFactor < 0 && past_positions.Count != 0)
        {
			gameObject.transform.position = past_positions.Pop();
        }
    }

    void StoreLocation()
    {
        if (TimeManager.timeFactor > 0)
        {
			past_positions.Push(transform.position);
			future_positions.Clear ();
			future_shots.Clear ();
			past_shots.Push(Input.GetButton("Fire1"));
        }
		if (TimeManager.timeFactor < 0) {
			future_positions.Push (gameObject.transform.position);
			if (past_shots.Count > 0) {
				future_shots.Push (past_shots.Pop());
			}
		}
    }
        
    void SetGunLocations()
    {
        leftGun = transform.position + horizScale * Vector3.left + vertScale * Vector3.up;
        rightGun = transform.position - horizScale * Vector3.left + vertScale * Vector3.up;
    }

	void SpawnClone() {
		GameObject clone = Instantiate (clone_prefab, gameObject.transform.position, transform.rotation);
		clone.GetComponent<CloneMovement> ().startUp (future_positions, future_shots);
		Debug.Log ("Spawned!");
	}
}

using UnityEngine;
using UnityEngine.UI;
using CnControls;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[Header(" Control Settings ")]
	public Rigidbody thisRigidbody;
	public SimpleJoystick joystick;
	public float moveSpeed;
	public float maxX;
	public float maxZ;
	bool move;
	public static bool canMove;
	public LayerMask lr;
	public GameObject heal;
	public Image imgheal;
	public GameObject effectls;
	bool die;

	void Start () {
		GetComponent<healthctr>().health = 300;
		// Store some values
		Application.targetFrameRate = 60;
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(joystick.HorizintalAxis.Value != 0 || joystick.VerticalAxis.Value != 0)
		{
			// Move Player
			move = true;	
			transform.forward = new Vector3(joystick.HorizintalAxis.Value, 0, joystick.VerticalAxis.Value);
			GetComponent<Animator>().Play("run");
		}
		else
		{
			move = false;
			GetComponent<Animator>().Play("idle");
		}

		if (GetComponent<healthctr>().health <= 0)
		{
			if(!die)
            {
				die = true;
				UiManager.instance.losegm();
            }
			//Destroy(gameObject);
		}

		Collider[] c = Physics.OverlapSphere(transform.position, 8.5f, lr);
		if(c.Length>0 || GetComponent<coincolid>().startheal)
        {
			heal.SetActive(true);
			imgheal.fillAmount = ((float)(GetComponent<healthctr>().health)) / 300;

			

		}
		else if (c.Length <= 0 || !GetComponent<coincolid>().startheal)
		{
			heal.SetActive(false);
		}
	}

	private void FixedUpdate() {

		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
		pos.z = Mathf.Clamp(pos.z, -maxZ, maxZ);
		transform.position = pos;

		if(canMove)
		{
			if(move)
				Move();
			else
				thisRigidbody.velocity = Vector3.zero;
		}
	}


	public void Move()
	{
		Vector3 movement = new Vector3(joystick.HorizintalAxis.Value, 0, joystick.VerticalAxis.Value);
		movement *= moveSpeed * Time.deltaTime;

		thisRigidbody.velocity = movement;
	}

	
}
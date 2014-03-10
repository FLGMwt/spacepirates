using UnityEngine;
using System.Collections;

public class DumbShip : MonoBehaviour {

	public float velocity; 
	public float maxVelocity;
	public float thrust = 1.0f;


	public Vector3 direction; 

	public Planet startPlanet; 
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


		if (Input.GetKey(KeyCode.W))
		{
			velocity += thrust * Time.deltaTime;

		}

		if (Input.GetKey(KeyCode.S))
		{
			velocity -= thrust * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.RotateAround(this.transform.position, Vector3.forward, 0.25f);
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.RotateAround(this.transform.position, Vector3.forward, -0.25f);
		}

		if (Input.GetKey(KeyCode.Q))
		{
			velocity = Mathf.Lerp(velocity, 0, thrust);
		}

		if (velocity > maxVelocity) velocity = maxVelocity;

		transform.position += transform.up * velocity * Time.deltaTime;
	}
}

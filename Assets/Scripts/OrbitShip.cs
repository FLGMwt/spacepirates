using UnityEngine;
using System.Collections;

public class OrbitShip : MonoBehaviour 
{

	public Planet target;

	private Vector3 desiredPosition;
	public float radius;
	public float radiusSpeed;
	//public float rotationSpeed = 80.0f;

	public float velocity;

	public int fuel;

	public bool hitSurface;
	public bool displayRadius;

	string travelToPlanet = "";
	

	// Use this for initialization
	void Start () 
	{
		transform.position = (transform.position - target.transform.position).normalized * radius + target.transform.position;
		target.UpdateActivePlanet(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Orbit();

	}

	void OnGUI()
	{
		travelToPlanet = GUI.TextField(new Rect(5, 30, 100, 20), travelToPlanet, 11);
		if (GUI.Button(new Rect(5, 55, 30, 20), "Go"))
		{
			Planet p = GameObject.Find(travelToPlanet).GetComponent<Planet>();
			ChangePlanets(p, 0);
			travelToPlanet = "";
		}
	}

	void Orbit()
	{
		//transform.RotateAround (target.transform.position, Vector3.forward, velocity * Time.deltaTime);

		transform.RotateAround (target.transform.position, Vector3.forward, velocity * Time.deltaTime);
		desiredPosition = (transform.position - target.transform.position).normalized * radius + target.transform.position;
		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

		if (Vector3.Distance(target.transform.position, this.transform.position) < target.surfaceDist) 
			hitSurface = true;
		else
		{
			hitSurface = false;
		}
	}
	
	public void ChangeRadius(float destinationRadius)
	{
		radius = destinationRadius;

	}

	public void ChangeVelocity()
	{

	}

	public void ChangePlanets(Planet p, float destinationRadius)
	{
		if (destinationRadius < p.atmosphereDist) destinationRadius = p.atmosphereDist + 1;

		target.UpdateActivePlanet(false);
		p.UpdateActivePlanet(true);


		target = p;
		radius = destinationRadius;

		Sun.Instance.ChangePlanet(p);

		//remove fuel somehow
	}
}
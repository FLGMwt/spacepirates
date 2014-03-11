using UnityEngine;
using System.Collections;

public class MapObject : MonoBehaviour 
{
	public Material trailMat;

	BuildFilledCircleMesh circleMesh;

	public Color defaultColor = Color.yellow;
	public Color selectedColor = Color.white;
	public Color hoverColor = Color.cyan;

	public string displayName;

	public float velocity;

	public bool activePlanet;
	public bool inWaypointList;

	public Transform target;

	public bool isMarkedAsWaypoint;

	// Use this for initialization
	void Start () 
	{
		if (!target) target = GameObject.Find ("map_Sun").GetComponent<Transform>();

		circleMesh = GetComponent<BuildFilledCircleMesh>();

		Initialize();
		transform.RotateAround(target.position, Vector3.forward, Random.Range(0, 360));

		this.renderer.material.color = defaultColor;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{	
			if (ClickHitObject())
			{
				if (!isMarkedAsWaypoint)
				{
					MapCamera.Instance.waypoints.Add(this);
					this.renderer.material.color = selectedColor;
					isMarkedAsWaypoint = true;
				}

				else
				{
					isMarkedAsWaypoint = false;
					MapCamera.Instance.waypoints.Remove(this);
					this.renderer.material.color = defaultColor;
				}
			}
		}

	}

	void FixedUpdate()
	{
		transform.RotateAround(target.position, Vector3.forward, velocity * GameManager.Instance.planetOrbitSpeedMultiplier);
	}

	bool ClickHitObject()
	{
		if(Vector3.Distance(this.renderer.bounds.center, MapCamera.Instance.cam.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5))) < circleMesh.radius)
		{
			return true;	
		}

		else
		{
			return false;
		}
	}

	void Initialize()
	{
		GameObject trail = new GameObject("trail");
		trail.transform.position = new Vector3(this.transform.position.x, transform.position.y, 5f);
		trail.AddComponent<TrailRenderer>();
		trail.transform.parent = this.transform;
		trail.renderer.material = this.trailMat;

		TrailRenderer tr = trail.GetComponent<TrailRenderer>();
		tr.startWidth = 0.05f;
		tr.endWidth = 0.01f;
		tr.time = 1300f;


	}
}

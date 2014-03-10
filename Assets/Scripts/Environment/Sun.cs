using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Light))]
public class Sun : MonoBehaviour {

	private static Sun instance;
	public static Sun Instance
	{
		get
		{
			if (instance == null) instance = new Sun();
			return instance;
		}
	}

	public float rotateSpeed;
	public float intensity;

	public LightType lightType;
	public Transform target;

	public bool doOrbit;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		UpdateTarget();
	}
	
	// Update is called once per frame
	void Update () 
	{
		light.intensity = intensity;
		light.type = lightType;

	}

	void FixedUpdate()
	{
		if (doOrbit)
		{
			Orbit();
		}
	}

	void Orbit()
	{
		transform.RotateAround(target.position, Vector3.forward, rotateSpeed);
	}

	public void ChangePlanet(Planet p)
	{
		target = p.transform;
		UpdateTarget();
	}

	void UpdateTarget()
	{
		if (target.GetComponent<Planet>())
		{
			rotateSpeed = target.GetComponent<Planet>().sunRotationSpeed * GameManager.Instance.planetOrbitSpeedMultiplier;
			transform.position = target.transform.position;
		}

		else
		{
			doOrbit = false;
			transform.position = Vector3.zero;
		}
	}
}

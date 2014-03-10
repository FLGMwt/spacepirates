using UnityEngine;
using System.Collections;
using Vectrosity;


public class Planet : MonoBehaviour 
{

	public static float G = 1.0f;

	//habitat stuff
	public int maxHabitats; 
	public float minHabitatDist;

	public float surfaceDist;
	public float atmosphereDist;
	public bool hasAtmosphere;
	public float sunRotationSpeed;

	public bool isActivePlanet;

	void Awake ()
	{
		UpdateActivePlanet(false);

	}

	// Use this for initialization
	void Start () 
	{
		minHabitatDist = surfaceDist + atmosphereDist + 1;

//		for testing purposes only
//		surfaceDist = transform.localScale.x / 2;
	}
	

	// Update is called once per frame
	void Update () 
	{

	}

	public void UpdateActivePlanet(bool active)
	{

		if (active)
		{
			this.renderer.enabled = true;
			isActivePlanet = true;
		}

		else
		{
			this.renderer.enabled = false;
			isActivePlanet = false;
		}
	}

}
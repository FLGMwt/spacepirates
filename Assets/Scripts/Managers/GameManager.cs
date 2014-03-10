using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	//static private MessengerHelper messengerHelper = ( new GameObject("MessengerHelper") ).AddComponent< MessengerHelper >();

	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null) instance = new GameManager();
			return instance;
		}
	}

	//planet stuff
	public float planetOrbitSpeedMultiplier = 1.0f;
	
	//asteroid stuff
	public GameObject asteroid;
	public GameObject asteroidRotator;
	
	public float asteroidMinDist;
	public float asteroidMaxDist;
	public float numAsteroids;
	
	public int randStationProb = 6;

	//habitat stuff
	public int maxScoreValue;

	//organization stuff

	
	void Awake()
	{
		instance = this;	
	}
	// Use this for initialization
	void Start () {
		//if not loading, distribute stations and asteroids
		
		
//		DistributeAsteroids();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void DistributeAsteroids()
	{
		
		for (int i = 0; i <numAsteroids; i++)
		{
			//get a random distance from the sun
			float x = Random.Range(asteroidMinDist, asteroidMaxDist);
			float y = Random.Range(asteroidMinDist, asteroidMaxDist);
			
			//rotate it 
			float rotate = Random.Range(0, 100000);
			
			//randomly determines if the asteroid is a station
			int hasStation = Random.Range(0, randStationProb+1);
			
			//assign the position and parent it to the rotator
			Vector3 pos = new Vector3(x, y, 0);
			
			GameObject inst = (GameObject)Instantiate(asteroid, pos, Quaternion.identity);
			inst.transform.RotateAround(Vector3.zero, Vector3.forward, rotate);
			inst.transform.parent = asteroidRotator.transform;
			
			
		}
		
	}
	
	void InitializeOrganizations()
	{
		
		
	}
}

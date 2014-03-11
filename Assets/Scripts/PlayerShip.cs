using UnityEngine;
using System.Collections;

public class PlayerShip : OrbitShip 
{
	private static PlayerShip instance;
	public static PlayerShip Instance
	{
		get
		{
			if(instance == null) instance = new PlayerShip();
			return instance;
		}
	}

	public bool isPlayerControlling;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Faction 
{
	public string name;
	public Planet origin;
	public Habitat habitatMain;

	public string currencyName;
	public float currencyPower;

	public int population;
	public int economy;
	public int militaryDiplomacy;
	public int technoLuddite;
	public int expansIsolationist;
	public int lawfulCriminal;


	public Faction(string n, Planet p)
	{
		FactionManager.Instance.listOrgs.Add(this);
		name = n;
		origin = p;
		//determine main habitat
		GenerateCurrency();
	}
	
	public Faction(string n, Planet p, Habitat h)
	{
		FactionManager.Instance.listOrgs.Add(this);
		name = n;
		origin = p;
		habitatMain = h;
		GenerateCurrency();
	}

	public Faction(string n, Planet p, Habitat h, string c, float cV)
	{
		FactionManager.Instance.listOrgs.Add(this);
		name = n;
		origin = p;
		habitatMain = h;
		currencyName = c;
		currencyPower = cV;
	}

	public Faction(string n, Planet p, Habitat h, string c, float cV, int milDip, int techLud, int expIso, int lawCrim)
	{
		FactionManager.Instance.listOrgs.Add(this);
		name = n;
		origin = p;
		habitatMain = h;
		currencyName = c;
		currencyPower = cV;
		militaryDiplomacy = milDip;
		technoLuddite = techLud;
		expansIsolationist = expIso;
		lawfulCriminal = lawCrim;
	}


	private void SeedPlanets(Planet p)
	{
		if (!origin) 
		{
			Debug.LogError("Faction could not seed a non existent planet.");
			return;
		}

		for (int i = 0; i < p.maxHabitats / 2; i++)
		{
			GameObject habitatObj = new GameObject();
//			habitatObj.AddComponent("Habitat");
//			Habitat habitat = (Habitat)habitatObj.GetComponent("Habitat");
//			habitat.parentPlanet = p;

			//habitatObj.AddComponent("Gravity");
			//Gravity g = (Gravity)habitatObj.GetComponent("Gravity");

		}
	}

	private void GenerateCurrency()
	{

	}

}//end faction

public class FactionManager : MonoBehaviour 
{
	
	private static FactionManager instance;
	public static FactionManager Instance
	{
		get
		{
			if (instance == null) instance = new FactionManager();
			return instance;
		}
	}
	
	public List<Faction> listOrgs = new List<Faction>();
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void BuildOrgList()
	{
//		Planet mercury = GameObject.Find("Mercury");
//		Faction mercuryFaction = new Faction("mercury faction", mercury);

		Planet earth = (Planet)GameObject.Find("Earth").GetComponent("Planet");
		Faction earthFaction = new Faction("earth faction", earth);

		Planet moon = (Planet)GameObject.Find("Moon").GetComponent("Planet");
		Faction moonFaction = new Faction("moon faction", moon);
//
//		Planet venus = GameObject.Find("Venus");
//		Faction venusFaction = new Faction("venus faction", venus);
	}
}

using UnityEngine;
using System.Collections;

public class Habitat : MonoBehaviour 
{
	public Planet parentPlanet;
	public float orbitDistance;
	public Faction org;

	public int industry;
	public int population;
	public int military;
	public int technology;

	public void Initialize()
	{

	}

	// Use this for initialization
	void Start () 
	{
		//Messenger.AddListener<Habitat>("test", TestMessenger);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			//Messenger.Broadcast<Habitat>("test");
		}
	}

	public void TestMessenger()
	{
		Debug.Log("habitat messenger test");
	}

	#region Adjust Scores
	public void AdjustIndustry(int value)
	{
		industry = ScoreAdjust(value);
	}

	public void AdjustPopulation(int value)
	{
		population = ScoreAdjust(value);
	}

	public void AdjustMilitary(int value)
	{
		military = ScoreAdjust(value);
	}

	public void AdjustTechnology(int value)
	{
		technology = ScoreAdjust(value);
	}

	private int ScoreAdjust(int value)
	{
		if (value > GameManager.Instance.maxScoreValue) return value = GameManager.Instance.maxScoreValue;
		else if (value < 0 ) return value = 0;
		else 
		{
			return value;
		}
	}

	#endregion
}

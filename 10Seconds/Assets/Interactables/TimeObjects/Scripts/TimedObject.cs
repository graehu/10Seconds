using UnityEngine;
using System.Collections;

public abstract class TimedObject : Interactable 
{
	
	#region public properties
	public float TimeRemaining
	{
		get {return resetTime-resetTick;}
	}
	#endregion
	
	
	#region public members
	public float resetTime = 10f;
	public Vector3 resetPosition;
	public ResetType type;
	#endregion
	
	#region private members
	public float resetTick = 0f;
	#endregion
	
	public enum ResetType
	{
		instant,
		reverse	
	}
	public abstract void Reset();
	
	
	//TODO: Find a real use for these.
	// Use this for initialization
	/*void  Start (){}
	
	// Update is called once per frame
	void Update (){}*/
}

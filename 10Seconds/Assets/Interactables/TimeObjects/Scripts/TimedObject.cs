using UnityEngine;
using System.Collections;

public abstract class TimedObject : Interactable 
{
	
	#region public properties
	public float TimeRemaining
	{
		get {return resetTime-resetTick;}
	}
	
	public bool IsDistrubed
	{
		get{return disturbed;}
	}
	#endregion
	
	#region public members
	public bool timeDependent = true;
	public float resetTime = 10f;
	public Vector3 resetPosition;
	public ResetType type;
	#endregion
	
	#region private members
	private float resetTick = 0f;
	private bool disturbed = false;
	#endregion
	public enum ResetType
	{
		instant,
		reverse	
	}	
	
	#region protected methods
	
	protected abstract void Reset();
	protected void TimeDisturbance() { if(timeDependent)disturbed = true; }

	protected void Update () 
	{
		if(disturbed)
		{
			resetTick += Time.deltaTime;
			if(resetTick >= resetTime)
			{
				disturbed = false;
				Reset();
			}
		}
		else resetTick = 0;
	}
	#endregion
	
	
	//TODO: Find a real use for these.
	// Use this for initialization
	/*void  Start (){}
	
	// Update is called once per frame
	*/
}

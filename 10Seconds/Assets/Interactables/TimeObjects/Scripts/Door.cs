using UnityEngine;
using System.Collections;

public class Door : TimedObject
{
	//Control the objects actual movements here too.
	#region public properties
	public bool IsOpen
	{
		get {return isOpen;}
		set {isOpen = value;}
	}
	#endregion
	
	#region public members
	public float changeTime;
	#endregion
	
	#region private members
	private bool isOpen = false;
	private bool resetValue = false;
	#endregion
	
	#region public methods
	public override void Reset()
	{
		isOpen = resetValue;
	}
	public override void Interact(CharacterController player){}
	public override void Disturbed(){}
	#endregion
	// Use this for initialization
	void Start () 
	{
		resetValue = isOpen;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

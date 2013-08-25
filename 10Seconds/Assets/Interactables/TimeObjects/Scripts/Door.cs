using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : TimedObject
{
	//Control the objects actual movements here too.
	#region public properties
	public bool IsClosed
	{
		get {return isOpen;}
		set {isClosing = value;}
	}
	#endregion
	
	#region public members
	public float changeTime;
	public List<Trigger> triggers;
	#endregion
	
	#region private members
	private bool isOpen = false;
	private bool isClosing = false;
	private bool resetValue = false;
	#endregion
	
	#region public methods
	protected override void Reset()
	{
		IsClosed = !resetValue;
	}
	public override void Interact(Transform player){}
	public override void StopInteraction(Transform player){}
	#endregion
	// Use this for initialization
	void Start () 
	{
		resetValue = isOpen;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//reset after
		base.Update();
		//
		
		for(int i = 0; i < triggers.Count; i++)
		{
			if(triggers[i].Fired)
			{
				isOpen = !isOpen;
				IsClosed = !isOpen;
				TimeDisturbance();
				if(isOpen)
				{
					Vector3 pos = transform.position;
					pos.y = 2;
					transform.position = pos;
				}
			}
		}
		if(isClosing)
		{
			TryClose();
		}
	}
	
	void TryClose()
	{
		Ray johnson = new Ray(transform.position, Vector3.down);
		if(!Physics.Raycast(johnson, 1f))
		{
			isOpen = false;
			isClosing = false;
			Vector3 pos = transform.position;
			pos.y = 1;
			transform.position = pos;
		}
	}
}

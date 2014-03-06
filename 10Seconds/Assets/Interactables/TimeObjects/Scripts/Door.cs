using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : TimedObject
{
	//Control the objects states here.
	#region public properties
	public bool IsClosed
	{
		get {return !isOpen;}
		set {isClosing = value;}
	}
	#endregion
	
	#region public members
	public float changeTime;
	public bool open = false;
	public List<Trigger> triggers;
	#endregion
	
	#region private members
	private bool isOpen = false;
	private bool isClosing = false;
	private Animator animator = null;
	#endregion
	
	#region public methods
	protected override void Reset()
	{
		IsClosed = !open;
		if(open)
			TryOpen();
		
	}
	public override void Interact(Transform player){}
	public override void StopInteraction(Transform player){}
	#endregion
	
	#region private methods
	void Start () 
	{
		animator = GetComponentInChildren<Animator>();
		if(open)
			TryOpen();
		
	}
	
	void Update ()
	{
		//reset after
		base.Update();
		//
		animator.SetBool("Closed", isOpen);
		
		for(int i = 0; i < triggers.Count; i++)
		{
			if(triggers[i].Fired)
			{
				isOpen = !isOpen;
				IsClosed = !isOpen;
				TimeDisturbance();
				if(isOpen)
				{
					collider.enabled = false;
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
		Vector3 origin = transform.position;
		origin.y++;
		Ray johnson = new Ray(origin, Vector3.down);
		if(!Physics.Raycast(johnson, 1f))
		{
			isOpen = false;
			isClosing = false;
			collider.enabled = true;
		}
	}
	void TryOpen()
	{
		isOpen = true;
		isClosing = false;
		IsClosed = false;
		collider.enabled = false;
	}
	#endregion
}

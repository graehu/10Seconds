using UnityEngine;
using System.Collections;

public abstract class Trigger : Interactable
{
	
	#region public members
	public int  numShots = 1;
	#endregion
	
	#region private members
	private int shotsFired = 0;
	private bool fired = false;
	#endregion
	
	#region public properties
	public bool Fired
	{
		get
		{
			bool fireVal = fired;
			shotsFired++;
			if(shotsFired == numShots)
				fired = false;
			return fireVal;
		}
	}
	#endregion
	
	#region public methods
	public override void  Interact(Transform interactor){Fire();}
	public override void  StopInteraction(Transform interactor) {}
	#endregion
	
	#region protected methods
	protected void Fire()
	{
		shotsFired = 0;
		fired = true;
	}
	#endregion
}

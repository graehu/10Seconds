using UnityEngine;
using System.Collections;

public abstract class Trigger : Interactable {
	
	public bool Fired
	{
		get
		{
			bool fireVal = fired;
			fired = false;
			return fireVal;
		}
	}
	
	private bool fired = false;
	public override void  Interact(Transform interactor) {fired = true;}
	//public void Disturbed() {}
	
	/*// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}//*/
}

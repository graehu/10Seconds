using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour {
	
	public bool IsDistrubed
	{
		get{return disturbed;}
	}
	private bool disturbed = false;
	
	public abstract void Interact(CharacterController player);
	public abstract void Disturbed();
}

using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour
{
	public bool IsInteracting
	{
		get {return (interactor != null)?true:false;}
	}
	//TODO: Make interactor into a stack at some point.
	protected Transform interactor;
	//
	public abstract void Interact(Transform _interactor);
	public abstract void StopInteraction(Transform _interactor);
	//public abstract void Disturbed();
}

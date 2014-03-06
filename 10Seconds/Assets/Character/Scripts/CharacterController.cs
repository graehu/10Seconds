using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	
	#region public members
	public dir faceDir;
	public CharacterStates state;
	#endregion
	
	#region private members
	private Ray williams;
	private Transform grabbedObject;
	private Interactable item;
	#endregion
	
	#region public types
	public enum dir
	{
		up,
		left,
		down,
		right
	}
	public enum CharacterStates
	{

		Walking,
		Interacting
	}
	#endregion
	
	#region private methods
	private void OnDrawGizmos()
	{
		if(Input.GetKey(KeyCode.Space))
		{
			Gizmos.DrawRay(transform.position, transform.forward*10);
		}
	}
	
	// Use this for initialization
	private void Start ()
	{
	
	}
	
	// Update is called once per frame
	private void Update ()
	{
		Vector3 rounding = transform.position;
		rounding.x = Mathf.Round(rounding.x);
		rounding.y = Mathf.Round(rounding.y);
		rounding.z = Mathf.Round(rounding.z);
		if(state == CharacterStates.Walking)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(item != null)
				{
					if(item.IsInteracting)
					{
						item.StopInteraction(transform);
					}
				}//*/
				
				TryInteract();
			}
			if(Input.GetKeyDown(KeyCode.W))
			{
				Move(dir.up);
			}
			if(Input.GetKeyDown(KeyCode.A))
			{
				Move(dir.left);
			}
			if(Input.GetKeyDown(KeyCode.S))
			{
				Move(dir.down);
			}
			if(Input.GetKeyDown(KeyCode.D))
			{
				Move(dir.right);
			}
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		else if(state == CharacterStates.Interacting)
		{
			if(Input.GetKeyDown (KeyCode.Space))
			{
				state = CharacterStates.Walking;
			}
		}
	}
	
	private bool TryInteract()
	{
		RaycastHit hit = new RaycastHit();
		Ray charles = new Ray(transform.position, transform.forward);
		
		Physics.Raycast(charles, out hit, 1f);
		if(hit.transform != null)
			item = hit.transform.GetComponent<Interactable>();
		else
			item = null;
		
		if(item != null)
		{
			item.Interact(transform);
			return true;
		}
		return false;		
	}
	private void Move(dir movedir)
	{
		faceDir = movedir;
		switch(movedir)
		{
		case dir.up:
			transform.forward = Vector3.forward;
			break;
		case dir.left:
			transform.forward = -Vector3.right;
			break;
		case dir.right:
			transform.forward = Vector3.right;
			break;
		case dir.down:
			transform.forward = -Vector3.forward;
			break;
		}
		
		Ray williams = new Ray(transform.position, transform.forward);
		
		if(!Physics.Raycast(williams, 1f))
		{
			Vector3 movePos = transform.position;
			movePos += transform.forward;
			transform.position = movePos;
		}

	}
	#endregion
}

using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	#region public members
	public dir faceDir;
	public CharacterStates state;
	public float walkInterval = 0.5f;
	#endregion

	#region private members
	private Ray williams;
	private Transform grabbedObject;
	private Interactable item;
	private float walkTimer = 0.0f;
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
		walkTimer += Time.deltaTime;
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
				faceDir = dir.up;
				if(walkTimer > walkInterval)
				{
					Move(dir.up);
					walkTimer = 0;
				}
			}
			else if(Input.GetKey(KeyCode.W) && walkTimer > walkInterval)
			{
				Move(dir.up);
				walkTimer = 0;
			}
			if(Input.GetKeyDown(KeyCode.A))
			{
				faceDir = dir.left;
				if(walkTimer > walkInterval)
				{
					Move(dir.left);
					walkTimer = 0;
				}
			}
			else if(Input.GetKey(KeyCode.A) && walkTimer > walkInterval)
			{
				Move(dir.left);
				walkTimer = 0;
			}
			if(Input.GetKeyDown(KeyCode.S))
			{
				faceDir = dir.down;
				if(walkTimer > walkInterval)
				{
					Move(dir.down);
					walkTimer = 0;
				}
			}
			else if(Input.GetKey(KeyCode.S) && walkTimer > walkInterval)
			{
					Move(dir.down);
					walkTimer = 0;
			}
			if(Input.GetKeyDown(KeyCode.D))
			{
				faceDir = dir.right;
				if(walkTimer > walkInterval)
				{
					Move(dir.right);
					walkTimer = 0;
				}
			}
			else if(Input.GetKey(KeyCode.D) && walkTimer > walkInterval)
			{
				Move(dir.right);
				walkTimer = 0;
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

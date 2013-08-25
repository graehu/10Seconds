using UnityEngine;
using System.Collections;

public class WeightedCube : TimedObject
{
	
	private Transform target;
	private Vector3 orignalPosition;
	
	protected override void Reset()
	{
		transform.position = orignalPosition;
		target = null;
	}	
	
	public override void Interact(Transform interactor)
	{
		target = interactor;
		TimeDisturbance();
	}
	
	private void Follow()
	{
		if(target != null)
		{
			Vector3 mypos = transform.position;
			Vector3 hispos = target.position;
			Vector3 rounding = transform.position;
			
			mypos.x = Mathf.Round(mypos.x);
			mypos.y = Mathf.Round(mypos.y);
			mypos.z = Mathf.Round(mypos.z);
			
			hispos.x = Mathf.Round(hispos.x);
			hispos.y = Mathf.Round(hispos.y);
			hispos.z = Mathf.Round(hispos.z);
			
			Vector3 dist = hispos - mypos;

			if(!(hispos.x == mypos.x || hispos.z == mypos.z))
			{
				target = null;
				return;
			}//*/
			//TODO: Make sure it doesn't go through things.
	
			//move x pos
			if(dist.x > 1)
				mypos.x += dist.x-1;
			else if (dist.x < -1)
				mypos.x += dist.x+1;
			
			//move y pos
			if(dist.z > 1)
				mypos.z += dist.z-1;
			else if (dist.z < -1)
				mypos.z += dist.z+1;
			
			
			if(!(transform.position == mypos))
			{
				transform.position = mypos;
				RaycastHit hit = new RaycastHit();
				Ray davies = new Ray(transform.position, Vector3.down);
				Physics.Raycast(davies, out hit, 1f);
				
				if(hit.transform != null)
				{
					Trigger trigger = hit.transform.GetComponent<Trigger>();
					if(trigger != null)
					{
						trigger.Interact(transform);
					}
				}
				
			}
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		orignalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		base.Update();
		Follow();
	}
}

using UnityEngine;
using System.Collections;

public class WeightedCube : TimedObject
{
	
	
	private Transform target;
	
	public override void Reset()
	{
		
	}
	
	public override void Interact(CharacterController player)
	{
		target = player.transform;
	}
	
	public override void Disturbed()
	{
		
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
			transform.position = mypos;

		}
	}
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Follow();
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePlate : Trigger
{
	public bool continuous = true;
	
	public List<Transform> weights;
	
	protected Transform currentWeight = null;
	
	public override void Interact(Transform interactor)
	{
		for(int i = 0; i < weights.Count; i++)
		{
			if(weights[i] == interactor)
			{
				if(continuous)
					currentWeight = interactor;
				base.Interact(interactor);
				Fire();
				break;
			}
		}
	}
	
	void Update()
	{
		if(continuous)
		{
			if(currentWeight != null)
			{
				Vector3 mypos = transform.position;
				Vector3 hispos = currentWeight.position;
				
				mypos.x = Mathf.Round(mypos.x);
				mypos.y = Mathf.Round(mypos.y);
				mypos.z = Mathf.Round(mypos.z);
				
				hispos.x = Mathf.Round(hispos.x);
				hispos.y = Mathf.Round(hispos.y);
				hispos.z = Mathf.Round(hispos.z);
				
				Vector3 dist = hispos - mypos;
	
				if(hispos.x != mypos.x || hispos.z != mypos.z)
				{
					currentWeight = null;
					Fire();
					return;
				}			
			}
		}
		else currentWeight = null;
	}
}

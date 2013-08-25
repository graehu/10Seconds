using UnityEngine;
using System.Collections;

public class UITimer : SpriteSheet
{
	public TimedObject timedObj = null;

	// Use this for initialization
	// Update is called once per frame
	protected void Update ()
	{
		base.Update();
		transform.forward = Camera.main.transform.forward;
		if(timedObj != null)
		{
			Vector3 hispos = timedObj.transform.position;
			hispos.y++;
			transform.position = hispos;
			
			if(!(timedObj.TimeRemaining < timedObj.resetTime))
			{
				
				SetRenderers(false);
				Reset ();
			}
			else
			{
				animate = true;
				SetRenderers(true);
			}
		}
	}
	
	void SetRenderers(bool _enabled)
	{
		renderer.enabled = _enabled;
	}
}

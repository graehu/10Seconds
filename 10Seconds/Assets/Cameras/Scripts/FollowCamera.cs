using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
	
	public float FollowDistance = 10f;
	public Transform player = null;
	
	// Update is called once per frame
	void LateUpdate ()
	{
		transform.position = player.position;
		transform.position -= (transform.forward*FollowDistance);
	}
}

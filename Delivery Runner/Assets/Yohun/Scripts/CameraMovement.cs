using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;

	void Start () 
    {
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () 
    {
		// transform.position = player.transform.position + offset;
        transform.position = new Vector3(transform.position.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
	}
}

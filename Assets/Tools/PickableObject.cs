using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour 
{
	public Transform leftIndex, leftThumb, rightIndex, rightThumb;

	private bool ifPicking = false;
	private bool ifPickingRight = false;
	private Transform initPalmTransformLeft, initPalmTransformRight, initObjectTransform;

	/*
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "bone1"
		   | collision.collider.name == "bone2"
		   | collision.collider.name == "bone3")  //Interact with hand.rrre
		{
			ifPicking = true;
			initObjectTransform = transform;
			if (collision.collider.tag == "LeftHand") 
			{
				ifPickingRight = false;
			} 
			else if (collision.collider.tag == "RightHand") 
			{
				ifPickingRight = true;
			}
		}
	}
	*/

	void Update()
	{
		if (Vector3.Distance (leftIndex.position, transform.position) < 0.02f 
			||Vector3.Distance (leftThumb.position, transform.position) < 0.02f)
		{
			ifPicking = true;
			ifPickingRight = false;
		}
		else if(Vector3.Distance (rightIndex.position, transform.position) < 0.02f
			||Vector3.Distance (rightThumb.position, transform.position) < 0.02f) 
		{
			ifPicking = true;
			ifPickingRight = true;
		}
		if (ifPicking) 
		{
			if (ifPickingRight) 
			{
				transform.position = (rightThumb.position + rightIndex.position) / 2;
				transform.rotation = rightThumb.rotation;
			} 
			else 
			{
				transform.position = (leftThumb.position + leftIndex.position) / 2;
				transform.rotation = leftThumb.rotation;
			}

			if (ifPickingRight) 
			{
				if (Vector3.Distance (rightIndex.position, transform.position) >= 0.02f
					|| Vector3.Distance (rightThumb.position, transform.position) >= 0.02f) 
				{
					ifPicking = false;
					transform.position = (rightThumb.position + rightIndex.position) / 2;
					transform.GetComponent<Rigidbody> ().velocity = new Vector3(0, 0, 0);
				}
			} 
			else 
			{
				if (Vector3.Distance (leftIndex.position, transform.position) >= 0.02f
					|| Vector3.Distance (leftThumb.position, transform.position) >= 0.02f) 
				{
					ifPicking = false;
					transform.position = (leftThumb.position + leftIndex.position) / 2;
					transform.GetComponent<Rigidbody> ().velocity = new Vector3(0, 0, 0);
				}
			}
		}
	}
}

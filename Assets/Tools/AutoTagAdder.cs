using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTagAdder : MonoBehaviour
{
	public Transform fatherObject;
	//public int targetLayer;
	public string targetTag;

	private List<Transform> _childObjects = new List<Transform> ();

	// Use this for initialization
	void Reset ()
    {		
		fatherObject = transform;
		//targetLayer = 8;
		//targetTag = "RightHand";
		targetTag = "LeftHand";

		_childObjects.Add (fatherObject);
		while (_childObjects.Count != 0) 
		{
			for (int i = 0; i < _childObjects.Count; i++) 
			{
				Transform child = _childObjects [i];
				for (int j = 0; j < child.childCount; j++)
					_childObjects.Add (child.GetChild (j));
				//child.gameObject.layer = targetLayer;
				child.tag = targetTag;

				_childObjects.Remove (child);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour {

	public string sortingLayerName = "Default";
	public int sortingOrderNumber = 0;

	void Awake ()
	{
		gameObject.GetComponent<MeshRenderer> ().sortingLayerName = sortingLayerName;
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = sortingOrderNumber;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

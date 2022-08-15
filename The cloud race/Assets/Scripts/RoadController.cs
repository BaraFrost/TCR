using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour {

	public enum Road
	{
		First,
		Second,
	}
		
	[SerializeField]
	private Transform _firstRoadPoint;

	[SerializeField]
	private Transform _secondRoadPoint;

	private float _firstRoadRadius;
	private float _secondRoadRadius;

	private void Start()
	{
		_firstRoadRadius = Vector3.Distance (_firstRoadPoint.position,transform.position);
		_secondRoadRadius = Vector3.Distance (_secondRoadPoint.position,transform.position);
		return;
		var d = GetRadius (Road.First);
	}

	public float GetRadius(Road road)
	{
		switch (road) {
		case Road.First:
			return _firstRoadRadius;
		case Road.Second:
			return _secondRoadRadius;
		default: 
			return 0;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{
	
	public class CharacterCloud : MonoBehaviour {
		
		[SerializeField]
		private Transform center;

		[SerializeField]
		private float radius = 2f, angularSpeed = 2f;
		private float positionX, positionY, angle;
		public float speed;
		public float Radius {set{ radius = value; }}
		private Vector2 direction = Vector2.left;
	
		private Vector2 moveVelocity;

		private void Start(){
			radius = Mathf.Sqrt (Mathf.Pow(center.position.x + gameObject.transform.position.x, 2) +
			Mathf.Pow (center.position.y + gameObject.transform.position.y, 2));
			angle = Mathf.PI * 3 / 2;
			SetPosition (angle);
		}

		private void Update(){
			
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (direction == Vector2.left) {
					direction = Vector2.right;
				} else {
					direction = Vector2.left;
				}
			}
			Move (direction);
		}

		private void SetPosition (float angle){
			positionX = center.position.x + Mathf.Cos(angle) * radius;
			positionY = center.position.y + Mathf.Sin(angle) * radius;
			transform.position = new Vector2(positionX, positionY);
		}

		private void Move(Vector2 direction){
			angle = angle + Time.deltaTime * angularSpeed * direction.x;
			if (angle >= 360f)
			{
				angle = 0f;
			}
			SetPosition(angle);
			gameObject.transform.LookAt (center,Vector3.right);
			RotateCharacter (center.position);
		}

		private void RotateCharacter(Vector3 center)
		{
			Vector3 xDirection = (center - transform.position).normalized;
			Vector3 yDirection = Quaternion.Euler (0, 0, 0) * xDirection;
			Vector3 zDirection = Vector3.forward;
			transform.rotation = Quaternion.LookRotation (zDirection,yDirection);
		}
	}
}
	




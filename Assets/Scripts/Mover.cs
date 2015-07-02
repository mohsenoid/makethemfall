using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	void Start ()
	{

	}

	void Update ()
	{
		if (GetComponent<Rigidbody2D> ().velocity == Vector2.zero) {
			GetComponent<Rigidbody2D> ().velocity = transform.up * GameController.speed;
		}

		if(GameController.paused){
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public Transform RightPlaceholder;
	public Transform LeftPlaceholder;
	public Collider2D RightWall;
	public Collider2D LeftWall;

	public GameController gameController;

	public enum PlayerStates
	{
		MovingLeft,
		MovingRight,
		StopedLeft,
		StopedRight
	}

	public PlayerStates state;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameController.paused) {
			switch (state) {
			case PlayerStates.MovingLeft:
				transform.position = Vector3.Lerp (transform.position, LeftPlaceholder.position, GameController.jumpSpeed);
				break;
			case PlayerStates.MovingRight:
				transform.position = Vector3.Lerp (transform.position, RightPlaceholder.position, GameController.jumpSpeed);
				break;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag.Contains ("Wall")) {
			//player hit wall
			switch (state) {
			case PlayerStates.MovingLeft:
				if (other.Equals (LeftWall))
					state = PlayerStates.StopedLeft;
				break;
			case PlayerStates.MovingRight:
				if (other.Equals (RightWall))
					state = PlayerStates.StopedRight;
				break;
			}
		} else if (other.tag.Contains ("ScoreLine")) {
			gameController.IncrementScore();
		} else if (other.tag.Contains ("Obsticle")){
			// Player hit obsticles
			GameController.paused = true;
		}
	}
}

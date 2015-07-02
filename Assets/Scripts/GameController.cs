using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public PlayerController LeftPlayer;
	public PlayerController RightPlayer;
	public static bool paused;

	public Text scoreText;

	public static int score;

	public float startSpeed=3;
	public float startJumpSpeed = 0.1f;


	public static float speed;
	public static float jumpSpeed;


	// Use this for initialization
	void Start ()
	{
		paused = false;
		speed = startSpeed;
		jumpSpeed = startJumpSpeed;
		score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void LeftTap ()
	{
		if (!GameController.paused) {
			switch (LeftPlayer.state) {
			case PlayerController.PlayerStates.StopedLeft:
				LeftPlayer.state = PlayerController.PlayerStates.MovingRight;
				break;
			case PlayerController.PlayerStates.StopedRight:
				LeftPlayer.state = PlayerController.PlayerStates.MovingLeft;
				break;
			}
		}
	}

	public void RightTap ()
	{
		if (!GameController.paused) {
			switch (RightPlayer.state) {
			case PlayerController.PlayerStates.StopedLeft:
				RightPlayer.state = PlayerController.PlayerStates.MovingRight;
				break;
			case PlayerController.PlayerStates.StopedRight:
				RightPlayer.state = PlayerController.PlayerStates.MovingLeft;
				break;
			}
		}
	}

	public void IncrementScore (){
		score++;
		scoreText.text = score.ToString();
	}


}

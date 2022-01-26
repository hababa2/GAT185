using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
	enum State
	{
		TITLE,
		GAME
	}

	[SerializeField] GameObject playerPrefab;
	[SerializeField] Transform playerSpawn;
	[SerializeField] GameObject titleScreen;
	[SerializeField] TMP_Text scoreUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] Slider healthBar;
	[SerializeField] Image healthBarFill;

	public float playerHealth { set { 
			healthBar.value = value;
			healthBarFill.color = Color.Lerp(new Color(1.0f, 0.0f, 0.0f), new Color(0.0f, 1.0f, 0.0f), value / 100.0f);
		} }

	public delegate void GameEvent();

	public event GameEvent startGameEvent;
	public event GameEvent stopGameEvent;

	int score = 0;
	int lives = 0;
	State state = State.TITLE;

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreUI.text = score.ToString();
		}
	}

	public int Lives
	{
		get { return lives; }
		set
		{
			lives = value;
			livesUI.text = "LIVES: " + lives.ToString();
		}
	}

	public void OnStartGame()
	{
		state = State.GAME;
		titleScreen.SetActive(false);

		Score = 0;
		Lives = 3;

		Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);

		startGameEvent?.Invoke();
	}

	public void OnStartTitle()
	{
		state = State.TITLE;
		titleScreen.SetActive(true);
		stopGameEvent?.Invoke();
	}

	public void OnStopGame()
	{

	}

	public void OnPlayerDead()
	{
		if(--Lives == 0)
		{
			OnStopGame();
		}
		else
		{
			Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
		}
	}
}
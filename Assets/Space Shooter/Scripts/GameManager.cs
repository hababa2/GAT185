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
		PLAYER_START,
		GAME,
		PLAYER_DEAD,
		GAME_OVER
	}

	[SerializeField] GameObject playerPrefab;
	[SerializeField] Transform playerSpawn;
	[SerializeField] BoxSpawner enemySpawner;
	[SerializeField] GameObject titleScreen;
	[SerializeField] GameObject gameOverScreen;
	[SerializeField] TMP_Text scoreUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] Slider healthBar;
	[SerializeField] Image healthBarFill;

	public float playerHealth
	{
		set
		{
			healthBar.value = value;
			healthBarFill.color = Color.Lerp(new Color(1.0f, 0.0f, 0.0f), new Color(0.0f, 1.0f, 0.0f), value / 100.0f);
		}
	}

	public delegate void GameEvent();

	public event GameEvent startGameEvent;
	public event GameEvent stopGameEvent;

	int score = 0;
	int lives = 0;
	State state = State.TITLE;
	float stateTimer = 0.0f;
	float gameTimer = 0.0f;

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

	private void Update()
	{
		stateTimer -= Time.deltaTime;

		switch (state)
		{
			case State.TITLE:
				break;
			case State.PLAYER_START:
				DestroyAllEnemies();
				Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
				startGameEvent?.Invoke();
				state = State.GAME;
				break;
			case State.GAME:
				gameTimer += Time.deltaTime;
				if(gameTimer > 5.0f)
				{
					gameTimer = 0.0f;
					enemySpawner.timeModifier = Mathf.Max(0.2f, enemySpawner.timeModifier - 0.1f);
				}
				break;
			case State.PLAYER_DEAD:
				if (stateTimer <= 0.0f)
				{
					state = State.PLAYER_START;
				}
				break;
			case State.GAME_OVER:
				if(stateTimer <= 0.0f)
				{
					state = State.TITLE;
					gameOverScreen.SetActive(false);
					titleScreen.SetActive(true);
				}
				break;
			default:
				break;
		}
	}

	public void OnStartGame()
	{
		state = State.PLAYER_START;
		titleScreen.SetActive(false);

		Score = 0;
		Lives = 3;
		gameTimer = 0.0f;
	}

	public void OnStartTitle()
	{
		state = State.TITLE;
		titleScreen.SetActive(true);
		stopGameEvent?.Invoke();
	}

	public void OnStopGame()
	{
		state = State.GAME_OVER;
		gameOverScreen.SetActive(true);
		stateTimer = 5.0f;
	}

	public void OnPlayerDead()
	{
		if (--Lives == 0)
		{
			OnStopGame();
		}
		else
		{
			state = State.PLAYER_DEAD;
			stateTimer = 3.0f;
		}

		stopGameEvent?.Invoke();
	}

	private void DestroyAllEnemies()
	{
		var spaceEnemies = FindObjectsOfType<SpaceEnemy>();
		foreach (var spaceEnemy in spaceEnemies)
		{
			Destroy(spaceEnemy.gameObject);
		}
	}
}
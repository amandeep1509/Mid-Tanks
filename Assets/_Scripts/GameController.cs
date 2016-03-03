using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount;
	public GameObject tank;
    public Text ScoreLabel;
    public Text LivesLabel;
    public Text GameOverLabel;
    public Text HighScoreLabel;
    public Button RestartButton;


    public PlayerController player;
    public EnemyController enemy;

    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;

    // PUBLIC ACCESS METHODS 
    public int ScoreValue
    {
        get
        {
            return _scoreValue;

        }
        set
        {
            this._scoreValue = value;
            Debug.Log(this._scoreValue);
            this.ScoreLabel.text = "Score: " + this._scoreValue;

        }
    }
    public int LivesValue
    {
        get
        {
            return _livesValue;
        }
        set
        {
            this._livesValue = value;
            Debug.Log(this._livesValue);
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }
	
	// Use this for initialization
	void Start () {
		this._GenerateTanks ();
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.GameOverLabel.gameObject.SetActive(false);
        this.HighScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}
    private void _endGame()
    {

        this.HighScoreLabel.text = "High Score: " + this._scoreValue;
        this.GameOverLabel.gameObject.SetActive(true);
        this.HighScoreLabel.gameObject.SetActive(true);
        this.LivesLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        this.player.gameObject.SetActive(false);
        this.enemy.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(true);

    }

    // PUBLIC METHODS

    //Method to restart the game when restart button clicked
    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}

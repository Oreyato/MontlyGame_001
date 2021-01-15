using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ScoreHealthManager : MonoBehaviour
{
    #region Public&Private Fields
    //Public:
	public float health = 3f;

    //Private:
    [SerializeField] private Text tHealth;
    [SerializeField] private Text tScore;
    [SerializeField] private Text tMultiplier;
	private float _currentHealth;
    private float _currentScore;
    private float _currentMultiplier;
    private GameManager _gameManager;

    #endregion
 
    #region Own Methods
	public void TakeDamage(float damage) {
        if (health <= 0f) {
            return;
        }

        _currentHealth -= damage;
        tHealth.text = "Life: " + _currentHealth.ToString();

        if (_currentHealth <= 0f){
            _gameManager.GameOver();
        }
    }

    #endregion

    #region Unity Methods
    void Start()
    {
        _currentHealth = health;
        _currentScore = 0f; //take score
        _currentMultiplier = 1f; //take multiplier

        _gameManager = Object.FindObjectOfType<GameManager>();

        tHealth.text = "Life: " + _currentHealth.ToString();
        tScore.text = "Score: " + _currentScore.ToString();
        tMultiplier.text = "Multiplier: x" + _currentMultiplier.ToString();

    }
    #endregion
}
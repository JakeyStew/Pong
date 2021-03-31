using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    private int _playerOneScore = 0;
    [SerializeField]
    private int _playerTwoScore = 0;
    private UI_Manager _UIManager;

    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if (_UIManager == null)
        {
            Debug.LogError("UI Manager missing on Game_Manager!");
        }
        _playerOneScore = 0;
        _playerTwoScore = 0;
    }

    public void AddScore(int scoreToAdd, int playerTag)
    {
        if (playerTag == 0)
        {
            _playerOneScore = _playerOneScore + scoreToAdd;
            _UIManager.UpdateScoresText(_playerOneScore, playerTag);
            Debug.Log("Score Added to Player 1 :" + _playerOneScore);
        }
        else if (playerTag == 1)
        {
            _playerTwoScore = _playerTwoScore + scoreToAdd;
            _UIManager.UpdateScoresText(_playerTwoScore, playerTag);
            Debug.Log("Score Added to Player 2 :" + _playerTwoScore);
        }
    }
}


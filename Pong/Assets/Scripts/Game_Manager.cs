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

    public void AddScore(int addPoint, string playerTag)
    {
        if (playerTag == "Player One")
        {
            _playerOneScore = _playerOneScore + addPoint;
            _UIManager.UpdateScoresText(_playerOneScore, playerTag);
        }
        else if (playerTag == "Player Two")
        {
            _playerTwoScore = _playerTwoScore + addPoint;
            _UIManager.UpdateScoresText(_playerTwoScore, playerTag);
        }
    }
}


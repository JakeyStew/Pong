using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _playerOneText;
    [SerializeField]
    private Text _playerTwoText;
    [SerializeField]
    private Text _spaceToStartText;

    void Start()
    {
        _playerOneText.text = "0";
        _playerTwoText.text = "0";
    }

    public void StartGame()
    {
        _spaceToStartText.gameObject.SetActive(false);
    }

    public void UpdateScoresText(int playerScore, string playerTag)
    {
        if (playerTag == "Player One")
        {
            _playerOneText.text = playerScore.ToString();
        }
        else if (playerTag == "Player Two")
        {
            _playerTwoText.text = playerScore.ToString();
        }
    }
}

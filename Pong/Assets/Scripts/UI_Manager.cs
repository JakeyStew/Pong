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

    public void UpdateScoresText(int scoreToAdd, int playerTag)
    {
        if (playerTag == 0)
        {
            _playerOneText.text = scoreToAdd.ToString();
        }
        else if (playerTag == 1)
        {
            _playerTwoText.text = scoreToAdd.ToString();
        }
    }
}

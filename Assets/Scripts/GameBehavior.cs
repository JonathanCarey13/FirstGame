using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public Stack<string> lootStack = new Stack<string>();
    public string labelText = "Collect all 4 items to win!";
    public int maxItems = 4;
    private int _playerHP = 10;
    private int _itemsCollected = 0;
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                TimeFreeze();
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }

    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                labelText = "You have died.";
                showLossScreen = true;
                TimeFreeze();
            }
            else
            {
                labelText = "Good god! That thing took a bite out of you!";
            }
        }
    }

    void TimeFreeze()
    {
        Time.timeScale = 0;
    }


    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel();
            }
        }
        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 -50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }
    }
}

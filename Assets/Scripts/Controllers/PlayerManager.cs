using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 100;
    public TextMeshProUGUI playerHpText;
    public static bool isGameOver;
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    private void Start()
    {
        isGameOver = false;
    }

    private void Update()
    {
        playerHpText.text = "" + playerHP;
        if (isGameOver)
        {
            // displayer game over screen here
        }
    }

    public void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
            isGameOver = true;
    }
}

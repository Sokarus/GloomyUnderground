using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //public BoardManager boardScript; - ��������� ���������� ����� (����������� ������, ��������)
    [HideInInspector] public bool playersTurn = true;

    private bool otherWorldTurn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitGame();
    }


    void InitGame()
    {
        //boardScript.SetupScene();
    }

    public void GameOver()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playersTurn || otherWorldTurn)
        {
            return;
        }

        StartOtherWorldTurn();
    }

    private void StartOtherWorldTurn()
    {
        otherWorldTurn = true;

        //StartCoroutine(DoOtherWorldActions()) - � ���� ���-�� ���������� ����� ������ ����. ���-�� ����-�� ������, ���-�� ������, ��� ��� �� ���.

        otherWorldTurn = false;
        playersTurn = true;
    }
}

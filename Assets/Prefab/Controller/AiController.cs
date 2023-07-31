using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    public int teamNumber;
    void PlayerTurn(int nTeam, Character.Base chara)
    {
        if (nTeam == teamNumber)
        {
            chara.YourTurn();
            GameController.instance.SimpleAiAttack();
        }
        else if (nTeam == -teamNumber)
        {
            chara.NextTurn();
        }
    }
    private void Start()
    {
        GameController.instance.gameState.AddListener(PlayerTurn);
    }
}

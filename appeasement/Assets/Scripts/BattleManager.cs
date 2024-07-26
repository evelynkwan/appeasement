using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    //VARIABLES//
    //The current turn you are on in the game (0 for player, 1 for enemy) 
    public int curTurn;

    //REFERENCES//
    private GameObject player;
    private BattleUI bui;

    //List of all enemies in a scene 
    public List<GameObject> enemies = new List<GameObject>();

    //Current enemy you're fighting 
    public int curEnemy;

    //The Player Actions Menu for the UI Buttons 
    public GameObject playerActionsMenu;
    public GameObject Dog;
    public GameObject Angy;
    public GameObject Something;
    private int randInt = 0;

    // Start is called before the first frame update
    void Start()
    {
        bui = GameObject.Find("Canvas").GetComponent<BattleUI>();
        playerActionsMenu.SetActive(true);
        player = GameObject.Find("KittyPlayer");
        randInt = Random.Range(1, 3);
        if (randInt == 1)
        {
            enemies.Add(Dog);
        }
        else if (randInt == 2)
        {
            enemies.Add(Angy);
        }
        else
        {
            enemies.Add(Something);
        }
        //Add each enemy in a scene to the Enemies List. 
        /*foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }*/
        

        //Set the current enemy to be the first enemy in the list 
        curEnemy = 0;

        //Set the current turn to 0 so it's the Player's turn first. 
        curTurn = 0;

        //Reset the turns so the player goes first.
        ResetTurns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Go to the next turn (Player or Enemy) after a turn has been completed 
    public void StartNextTurn()
    {
        //0 - Player's Turn, 1 = Enemy's Turn 
        //If the current turn is higher than the enemy's (1)
        //Reset the Turns.

        //Add 1 to the current turn.
        curTurn++; 

        //If the enemy had a turn, reset the turn back to the player. 
        if(curTurn >= 2)
        {
            Debug.Log("PLAYER'S TURN");
            ResetTurns();
        }

        //Otherwise, if the Player had a turn, switch to the Enemy's turn. 
        else if(curTurn == 1)
        {
            Debug.Log("ENEMY'S TURN");
            playerActionsMenu.SetActive(false);
            if (curEnemy >= enemies.Count)
            {
                Debug.Log("VICTORY");
            }

            else if(curEnemy < enemies.Count)
            {
                //Allow the enemy to attack or perform an action on the player.
                enemies[curEnemy].GetComponent<EnemyAction>().Attack(player.GetComponent<PlayerAction>());
            }
 
        }
    }

    //Resets back to the Player's Turn & allow UI functionality again.
    public void ResetTurns()
    {
        Debug.Log("RESET TURNS");
        curTurn = 0;
        playerActionsMenu.SetActive(true);
        bui.specialButton.SetActive(true);
    }

    //If all enemies are gone, indicate to the player that they won and they can move onto the next stage.
    public void NextStage()
    {

    }
}

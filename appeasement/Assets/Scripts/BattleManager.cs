using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    //VARIABLES//
    //The current turn you are on in the game (0 for player, 1 for enemy) 
    public int curTurn;
    public bool upgrades;
    public int curLevel;
    public int loopDep;
    public int randInt2;
    public int[] randStorage;
    public bool isBattle;
    public string nextSceneName;
    public string loseSceneName;

    //REFERENCES//
    private GameObject player;
    private BattleUI bui;
    private UnitStats playerUnitStats;
    private MusicPlayer music;

    //List of all enemies in a scene 
    public List<GameObject> enemies = new List<GameObject>();

    //Current enemy you're fighting 
    public int curEnemy;

    //The Player Actions Menu for the UI Buttons 
    public GameObject playerActionsMenu;
    public GameObject Dog;
    public GameObject Angy;
    public GameObject Something;
    public GameObject God;
    private int randInt = 0;

    // Start is called before the first frame update
    void Start()
    {
        upgrades = false;
        isBattle = true;
        randInt2 = 0;
        randStorage = new int[] { 0, 0 };
        loopDep = 0;
        curLevel = 1;
        bui = GameObject.Find("Canvas").GetComponent<BattleUI>();
        playerActionsMenu.SetActive(true);
        player = GameObject.Find("KittyPlayer");
        playerUnitStats = player.GetComponent<UnitStats>();
        music = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
        randInt = Random.Range(1, 4);
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
        if (isBattle)
        {
            music.NormalBattle(upgrades, curLevel >= 20);
        }
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
            if (playerUnitStats.health <= 0)
            {
                Debug.Log("LOSER");
                if (!string.IsNullOrEmpty(loseSceneName))
                {
                    SceneManager.LoadScene(loseSceneName);
                }
                else
                {
                    Debug.LogError("Next scene name is not set.");
                }
            }
            else
            {
                ResetTurns();
            }
        }

        //Otherwise, if the Player had a turn, switch to the Enemy's turn. 
        else if(curTurn == 1)
        {
            Debug.Log("ENEMY'S TURN");
            playerActionsMenu.SetActive(false);
            if (curEnemy >= enemies.Count)
            {
                if (curLevel >= 20)
                {
                    Debug.Log("GOD_DOWN");
                    playerActionsMenu.SetActive(false);
                    isBattle = false;
                    if (!string.IsNullOrEmpty(nextSceneName))
                    {
                        SceneManager.LoadScene(nextSceneName);
                    }
                    else
                    {
                        Debug.LogError("Next scene name is not set.");
                    }
                }
                else
                {
                    Debug.Log("VICTORY");
                    playerActionsMenu.SetActive(false);
                    upgrades = true;
                }
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
        if (bui.meterValue < playerUnitStats.meterCost)
        {
            bui.specialButton.SetActive(false);
            Debug.Log("IDK");
        }
        else
        {
            bui.specialButton.SetActive(true);
        }
    }

    //If all enemies are gone, indicate to the player that they won and they can move onto the next stage.
    public void NextStage()
    {
        enemies.Clear();
        curEnemy = 0;
        if (curLevel == 19)
        {
            enemies.Add(God);
        }
        else
        {
            randInt = Random.Range(1, 4);
            if (randInt == 1)
            {
                enemies.Add(Dog);
                enemies[curEnemy].GetComponent<UnitStats>().max_health = 20;
                enemies[curEnemy].GetComponent<UnitStats>().health = 20;
                enemies[curEnemy].GetComponent<UnitStats>().attack = 3;
                enemies[curEnemy].GetComponent<UnitStats>().defense = 0;
            }
            else if (randInt == 2)
            {
                enemies.Add(Angy);
                enemies[curEnemy].GetComponent<UnitStats>().max_health = 15;
                enemies[curEnemy].GetComponent<UnitStats>().health = 15;
                enemies[curEnemy].GetComponent<UnitStats>().attack = 4;
                enemies[curEnemy].GetComponent<UnitStats>().defense = -1;
            }
            else
            {
                enemies.Add(Something);
                enemies[curEnemy].GetComponent<UnitStats>().max_health = 25;
                enemies[curEnemy].GetComponent<UnitStats>().health = 25;
                enemies[curEnemy].GetComponent<UnitStats>().attack = 2;
                enemies[curEnemy].GetComponent<UnitStats>().defense = 0;
            }
            loopDep = 1;
            randStorage = new int[] { 0, 0 };
            while (loopDep <= curLevel)
            {
                randInt2 = Random.Range(1, 4);
                while (randStorage.Contains<int>(randInt2))
                {
                    randInt2 = Random.Range(1, 4);
                }
                if (randStorage[0] == 0)
                {
                    randStorage[0] = randInt2;
                }
                else if (randStorage[1] == 0)
                {
                    randStorage[1] = randInt2;
                }
                else
                {
                    randStorage = new int[] { 0, 0 };
                }
                if (randInt2 == 1)
                {
                    enemies[curEnemy].GetComponent<UnitStats>().attack += 1;
                }
                else if (randInt2 == 2)
                {
                    enemies[curEnemy].GetComponent<UnitStats>().defense += 1;
                }
                else
                {
                    enemies[curEnemy].GetComponent<UnitStats>().max_health += 3;
                }
                loopDep += 1;
            }
        }
        curLevel += 1;
        bui.meterValue = 5;
        playerUnitStats.health = playerUnitStats.max_health;
        bui.playerHP.maxValue = player.GetComponent<UnitStats>().max_health;
        enemies[curEnemy].GetComponent<UnitStats>().health = enemies[curEnemy].GetComponent<UnitStats>().max_health;
        bui.enemyHP.maxValue = enemies[curEnemy].GetComponent<UnitStats>().max_health;
        ResetTurns();
    }
    public void Retry()
    {
        curLevel = 0;    
        playerUnitStats.max_health = 20;
        playerUnitStats.health = 20;
        playerUnitStats.attack = 3;
        playerUnitStats.defense = 1;
        playerUnitStats.guardAmount = 1;
        playerUnitStats.meterCost = 10;
        playerUnitStats.meterRate = 1;
        playerUnitStats.specialattack = 18;
        playerUnitStats.dead = false;
        NextStage();
    }
}

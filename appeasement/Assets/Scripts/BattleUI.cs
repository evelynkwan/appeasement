using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//Used for the UI for interacting with the combat system (Attacking, Special, Defend, etc.) 
public class BattleUI : MonoBehaviour
{
    //REFERENCES//
    public Slider apMeter;
    public int meterValue;
    private GameObject player;
    private GameObject enemy;
    private PlayerAction playerActionScript;
    private BattleManager bm;
    public TMP_Text playerHPNumber;
    public TMP_Text enemyHPNumber;
    public Slider playerHP;
    public Slider enemyHP;
    public GameObject Something;
    public GameObject Angy;
    public GameObject Dog;
    public GameObject SomethingUI;
    public GameObject AngyUI;
    public GameObject DogUI;
    public GameObject specialButton;
    private UnitStats playerUnitStats;
    public GameObject angryFace;
    public GameObject unhappyFace;
    public GameObject mehFace;
    public GameObject happyFace;
    public GameObject appeasedFace;

    // Start is called before the first frame update
    void Start()
    {
        meterValue = 4;
        apMeter.value = 0.9665f;
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        player = GameObject.Find("KittyPlayer");
        playerUnitStats = player.GetComponent<UnitStats>();
        enemy = bm.enemies[bm.curEnemy];
        playerActionScript = player.GetComponent<PlayerAction>();
        playerHP.maxValue = player.GetComponent<UnitStats>().max_health;
        playerHP.value = player.GetComponent<UnitStats>().health;
        enemyHP.maxValue = enemy.GetComponent<UnitStats>().max_health;
        enemyHP.value = enemy.GetComponent<UnitStats>().health;
        playerHPNumber.text = player.GetComponent<UnitStats>().max_health.ToString();
        if (bm.enemies[bm.curEnemy] == Dog)
        {
            DogUI.SetActive(true);
            SomethingUI.SetActive(false);
            AngyUI.SetActive(false);
        }
        else if (bm.enemies[bm.curEnemy] == Something)
        {
            DogUI.SetActive(false);
            SomethingUI.SetActive(true);
            AngyUI.SetActive(false);
        }
        else
        {
            DogUI.SetActive(false);
            SomethingUI.SetActive(false);
            AngyUI.SetActive(true);
        }
        //hpSlider.maxValue = playerUnitStats.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        apMeter.value = (meterValue * 0.008375f) + 0.933f;
        if (meterValue < playerUnitStats.meterCost)
        {
            specialButton.SetActive(false);
            Debug.Log("IDK");
        }
        if (meterValue >= 8)
        {
            appeasedFace.SetActive(true);
            happyFace.SetActive(false);
            mehFace.SetActive(false);
            unhappyFace.SetActive(false);
            angryFace.SetActive(false);
        }
        else if (meterValue >= 6)
        {
            appeasedFace.SetActive(false);
            happyFace.SetActive(true);
            mehFace.SetActive(false);
            unhappyFace.SetActive(false);
            angryFace.SetActive(false);
        }
        else if (meterValue >= 4)
        {
            appeasedFace.SetActive(false);
            happyFace.SetActive(false);
            mehFace.SetActive(true);
            unhappyFace.SetActive(false);
            angryFace.SetActive(false);
        }
        else if (meterValue >= 2)
        {
            appeasedFace.SetActive(false);
            happyFace.SetActive(false);
            mehFace.SetActive(false);
            unhappyFace.SetActive(true);
            angryFace.SetActive(false);
        }
        else
        {
            appeasedFace.SetActive(false);
            happyFace.SetActive(false);
            mehFace.SetActive(false);
            unhappyFace.SetActive(false);
            angryFace.SetActive(true);
        }
        //ENSURE that the HP slider always updates with the player's current health
        playerHP.value = player.GetComponent<UnitStats>().health;
        if (player.GetComponent<UnitStats>().health < 0)
        {
            playerHPNumber.text = "0";
        }
        else
        {
            playerHPNumber.text = player.GetComponent<UnitStats>().health.ToString();
        }
        if(enemy.GetComponent<UnitStats>().health < 0)
        {
            enemyHPNumber.text = "0";
        }
        else
        {
            enemyHPNumber.text = enemy.GetComponent<UnitStats>().health.ToString();
        }

        if (bm.curEnemy < bm.enemies.Count)
        {
            enemy = bm.enemies[bm.curEnemy];
            enemyHP.value = enemy.GetComponent<UnitStats>().health;
            if (bm.enemies[bm.curEnemy] == Dog)
            {
                DogUI.SetActive(true);
                SomethingUI.SetActive(false);
                AngyUI.SetActive(false);
                Dog.SetActive(true);
                Something.SetActive(false);
                Angy.SetActive(false);
                Debug.Log("DOG");
            }
            if (bm.enemies[bm.curEnemy] == Something)
            {
                DogUI.SetActive(false);
                SomethingUI.SetActive(true);
                AngyUI.SetActive(false);
                Dog.SetActive(false);
                Something.SetActive(true);
                Angy.SetActive(false);
            }
            if (bm.enemies[bm.curEnemy] == Angy) 
            {
                DogUI.SetActive(false);
                SomethingUI.SetActive(false);
                AngyUI.SetActive(true);
                Dog.SetActive(false);
                Something.SetActive(false);
                Angy.SetActive(true);
            }
        }
        else
        {
            enemyHP.value = 0;
            Dog.SetActive(false);
            Something.SetActive(false);
            Angy.SetActive(false);
        }
    }

    //Use for the UI Buttons in the Player Actions Menu//
    public void AttackButton()
    {
        //Attacks the current enemy on-screen and calls their TakeDamage method so they take damage.
        playerActionScript.Attack(bm.enemies[bm.curEnemy].GetComponent<EnemyAction>());
    }

    public void SpecialButton()
    {
        playerActionScript.Special(bm.enemies[bm.curEnemy].GetComponent<EnemyAction>());
    }

    public void DefendButton()
    {
        playerActionScript.Defend();
    }
}

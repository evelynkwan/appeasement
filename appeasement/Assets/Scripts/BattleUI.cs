using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

//Used for the UI for interacting with the combat system (Attacking, Special, Defend, etc.) 
public class BattleUI : MonoBehaviour
{
    //REFERENCES//
    public Slider apMeter;
    public int meterValue;
    public int randInt1;
    public int randInt2;
    public int randInt3;
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
    public GameObject God;
    public GameObject GodUI;
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
    public GameObject upgradePanel;
    public GameObject upgradeParent;
    public GameObject firstUpgrade;
    public GameObject secondUpgrade;
    public GameObject thirdUpgrade;
    public Sprite upgrade1;
    public Sprite upgrade2;
    public Sprite upgrade3;
    public Sprite upgrade4;
    public Sprite upgrade5;
    public Sprite upgrade6;
    public Sprite upgrade7;
    public int[] randomStorage;
    public bool hasRandomized;
    public TMP_Text floorNumber;
    public GameObject background;
    public GameObject background2;

    // Start is called before the first frame update
    void Start()
    {
        meterValue = 5;
        apMeter.value = 0.975175f;
        background.GetComponent<SpriteRenderer>().color = new Color(0.67f, 0.44f, 0.26f);
        background2.GetComponent<SpriteRenderer>().color = new Color(0.44f, 0.29f, 0.18f);
        floorNumber.text = "FLOOR 1";
        randomStorage = new int[] {0, 0, 0, 0};
        hasRandomized = true;
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
        apMeter.value = (meterValue * 0.004965f) + 0.95035f;
        floorNumber.text = "FLOOR " + bm.curLevel;
        if (meterValue < playerUnitStats.meterCost)
        {
            specialButton.SetActive(false);
            Debug.Log("IDK");
        }
        if (meterValue >= 10)
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
        else if (meterValue >= 5)
        {
            appeasedFace.SetActive(false);
            happyFace.SetActive(false);
            mehFace.SetActive(true);
            unhappyFace.SetActive(false);
            angryFace.SetActive(false);
        }
        else if (meterValue >= 3)
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
        if (player.GetComponent<UnitStats>().health < 0 || playerUnitStats.dead)
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
                God.SetActive(false);
                GodUI.SetActive(false);
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
                God.SetActive(false);
                GodUI.SetActive(false);
            }
            if (bm.enemies[bm.curEnemy] == Angy) 
            {
                DogUI.SetActive(false);
                SomethingUI.SetActive(false);
                AngyUI.SetActive(true);
                Dog.SetActive(false);
                Something.SetActive(false);
                Angy.SetActive(true);
                God.SetActive(false);
                GodUI.SetActive(false);
            }
            if (bm.enemies[bm.curEnemy] == God)
            {
                DogUI.SetActive(false);
                SomethingUI.SetActive(false);
                AngyUI.SetActive(false);
                Dog.SetActive(false);
                Something.SetActive(false);
                Angy.SetActive(false);
                God.SetActive(true);
                GodUI.SetActive(true);
                background.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                background2.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);
            }
        }
        else
        {
            enemyHP.value = 0;
            Dog.SetActive(false);
            Something.SetActive(false);
            God.SetActive(false);
            Angy.SetActive(false);
        }
        if (bm.upgrades) {
            if (hasRandomized)
            {
                hasRandomized = false;
                randomStorage = new int[] { 0, 0, 0, 0 };
                if (playerUnitStats.meterCost <= 1)
                {
                    randomStorage[2] = 6;
                }
                if (playerUnitStats.meterRate >= 10)
                {
                    randomStorage[3] = 5;
                }
                upgradePanel.SetActive(true);
                upgradeParent.SetActive(true);
                randInt1 = UnityEngine.Random.Range(1, 8);
                while (randomStorage.Contains<int>(randInt1))
                {
                    randInt1 = UnityEngine.Random.Range(1, 8);
                }
                randomStorage[0] = randInt1;
                if (randInt1 == 1)
                {
                    firstUpgrade.GetComponent<Image>().sprite = upgrade1;
                }
                else if (randInt1 == 2)
                {
                    firstUpgrade.GetComponent<Image>().sprite = upgrade2;
                }
                else if (randInt1 == 3)
                {
                    firstUpgrade.GetComponent<Image>().sprite = upgrade3;
                }
                else if (randInt1 == 4)
                {
                    firstUpgrade.GetComponent<Image>().sprite = upgrade4;
                }
                else if (randInt1 == 5)
                {
                    firstUpgrade.GetComponent<Image>().sprite = upgrade5;
                }
                else if (randInt1 == 6)
                {
                    firstUpgrade.GetComponent<Image>().sprite = upgrade6;
                }
                else
                {
                    firstUpgrade.GetComponent<Image>().sprite = upgrade7;
                }
                randInt2 = UnityEngine.Random.Range(1, 8);
                while (randomStorage.Contains<int>(randInt2))
                {
                    randInt2 = UnityEngine.Random.Range(1, 8);
                }
                randomStorage[1] = randInt2;
                if (randInt2 == 1)
                {
                    secondUpgrade.GetComponent<Image>().sprite = upgrade1;
                }
                else if (randInt2 == 2)
                {
                    secondUpgrade.GetComponent<Image>().sprite = upgrade2;
                }
                else if (randInt2 == 3)
                {
                    secondUpgrade.GetComponent<Image>().sprite = upgrade3;
                }
                else if (randInt2 == 4)
                {
                    secondUpgrade.GetComponent<Image>().sprite = upgrade4;
                }
                else if (randInt2 == 5)
                {
                    secondUpgrade.GetComponent<Image>().sprite = upgrade5;
                }
                else if (randInt2 == 6)
                {
                    secondUpgrade.GetComponent<Image>().sprite = upgrade6;
                }
                else
                {
                    secondUpgrade.GetComponent<Image>().sprite = upgrade7;
                }
                randInt3 = UnityEngine.Random.Range(1, 8);
                while (randomStorage.Contains<int>(randInt3))
                {
                    randInt3 = UnityEngine.Random.Range(1, 8);
                }
                if (randInt3 == 1)
                {
                    thirdUpgrade.GetComponent<Image>().sprite = upgrade1;
                }
                else if (randInt3 == 2)
                {
                    thirdUpgrade.GetComponent<Image>().sprite = upgrade2;
                }
                else if (randInt3 == 3)
                {
                    thirdUpgrade.GetComponent<Image>().sprite = upgrade3;
                }
                else if (randInt3 == 4)
                {
                    thirdUpgrade.GetComponent<Image>().sprite = upgrade4;
                }
                else if (randInt3 == 5)
                {
                    thirdUpgrade.GetComponent<Image>().sprite = upgrade5;
                }
                else if (randInt3 == 6)
                {
                    thirdUpgrade.GetComponent<Image>().sprite = upgrade6;
                }
                else
                {
                    thirdUpgrade.GetComponent<Image>().sprite = upgrade7;
                }
            }
        }
        else
        {
            upgradePanel.SetActive(false);
            upgradeParent.SetActive(false);
            hasRandomized = true;
        }
    }

    public void FirstUpgrade()
    {
        if (randInt1 == 1)
        {
            playerUnitStats.attack += 1;
        }
        else if (randInt1 == 2)
        {
            playerUnitStats.guardAmount += 2;
        }
        else if (randInt1 == 3)
        {
            playerUnitStats.defense += 1;
        }
        else if (randInt1 == 4)
        {
            playerUnitStats.max_health += 5;
        }
        else if (randInt1 == 5)
        {
            playerUnitStats.meterRate += 1;
        }
        else if (randInt1 == 6)
        {
            if (playerUnitStats.meterCost <= 1)
            {
                playerUnitStats.meterCost = 1;
            }
            else
            {
                playerUnitStats.meterCost -= 1;
            }
        }
        else
        {
            playerUnitStats.specialattack += 1;
        }
        bm.upgrades = false;
        bm.NextStage();
    }

    public void SecondUpgrade()
    {
        if (randInt2 == 1)
        {
            playerUnitStats.attack += 1;
        }
        else if (randInt2 == 2)
        {
            playerUnitStats.guardAmount += 2;
        }
        else if (randInt2 == 3)
        {
            playerUnitStats.defense += 1;
        }
        else if (randInt2 == 4)
        {
            playerUnitStats.max_health += 5;
        }
        else if (randInt2 == 5)
        {
            playerUnitStats.meterRate += 1;
        }
        else if (randInt2 == 6)
        {
            if (playerUnitStats.meterCost <= 1)
            {
                playerUnitStats.meterCost = 1;
            }
            else
            {
                playerUnitStats.meterCost -= 1;
            }
        }
        else
        {
            playerUnitStats.specialattack += 1;
        }
        bm.upgrades = false;
        bm.NextStage();
    }

    public void ThirdUpgrade()
    {
        if (randInt3 == 1)
        {
            playerUnitStats.attack += 1;
        }
        else if (randInt3 == 2)
        {
            playerUnitStats.guardAmount += 2;
        }
        else if (randInt3 == 3)
        {
            playerUnitStats.defense += 1;
        }
        else if (randInt3 == 4)
        {
            playerUnitStats.max_health += 5;
        }
        else if (randInt3 == 5)
        {
            playerUnitStats.meterRate += 1;
        }
        else if (randInt3 == 6)
        {
            if (playerUnitStats.meterCost <= 1)
            {
                playerUnitStats.meterCost = 1;
            }
            else
            {
                playerUnitStats.meterCost -= 1;
            }
        }
        else
        {
            playerUnitStats.specialattack += 1;
        }
        bm.upgrades = false;
        bm.NextStage();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used for the UI for interacting with the combat system (Attacking, Special, Defend, etc.) 
public class BattleUI : MonoBehaviour
{
    //REFERENCES//
    private GameObject player;
    private PlayerAction playerActionScript;
    private BattleManager bm;

    public Slider playerHP;

    // Start is called before the first frame update
    void Start()
    {
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        player = GameObject.Find("KittyPlayer");
        playerActionScript = player.GetComponent<PlayerAction>();
        playerHP.maxValue = player.GetComponent<UnitStats>().max_health;
        playerHP.value = player.GetComponent<UnitStats>().health;
        //hpSlider.maxValue = playerUnitStats.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //ENSURE that the HP slider always updates with the player's current health
        playerHP.value = player.GetComponent<UnitStats>().health;
    }

    //Use for the UI Buttons in the Player Actions Menu//
    public void AttackButton()
    {
        //Attacks the current enemy on-screen and calls their TakeDamage method so they take damage.
        playerActionScript.Attack(bm.enemies[bm.curEnemy].GetComponent<EnemyAction>());
    }

    public void SpecialButton()
    {

    }

    public void DefendButton()
    {

    }
}

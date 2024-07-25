using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for the UI for interacting with the combat system (Attacking, Special, Defend, etc.) 
public class BattleUI : MonoBehaviour
{
    //REFERENCES//
    private GameObject player;
    private PlayerAction playerActionScript;
    private BattleManager bm; 

    // Start is called before the first frame update
    void Start()
    {
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        player = GameObject.Find("KittyPlayer");
        playerActionScript = player.GetComponent<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

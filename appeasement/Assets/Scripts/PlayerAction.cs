using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //VARIABLES//

    //REFERENCES//
    private UnitStats playerUnitStats;
    private int guardBoost;

    private BattleManager bm;
    private BattleUI bui;
    public TMP_Text playerHPNumber;
    // Start is called before the first frame update
    void Start()
    {
        playerUnitStats = GetComponent<UnitStats>();
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        bui = GameObject.Find("Canvas").GetComponent<BattleUI>();
        guardBoost = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        if ( (damageAmount - guardBoost - playerUnitStats.defense) >= 1)
        {
            playerUnitStats.health -= (damageAmount - guardBoost - playerUnitStats.defense);
        }
        else
        {
            playerUnitStats.health -= 1;
        }
        if (playerUnitStats.health <= 0)
        {
            playerHPNumber.text = "0";
            bui.playerHP.value = 0;
            Destroy(this.gameObject);
            Debug.Log("DED LMAO");
        }
    }

    public void Attack(EnemyAction targetEnemy)
    {
        guardBoost = 0;
        targetEnemy.TakeDamage(playerUnitStats.attack);
        Debug.Log("TAKEN DAMAGE");
        bm.playerActionsMenu.SetActive(false);
        Invoke("CallTurnAfterDelay", 1f);
    }

    public void Defend()
    {
        guardBoost = playerUnitStats.guardAmount;
        if (bui.meterValue < 10)
        {
            bui.meterValue += playerUnitStats.meterRate;
            if (bui.meterValue > 10) {
                bui.meterValue = 10;
            }
        }
        Debug.Log("GUARDED");
        bm.playerActionsMenu.SetActive(false);
        Invoke("CallTurnAfterDelay", 1f);
    }

    public void Special(EnemyAction targetEnemy)
    {
        guardBoost = 0;
        bui.meterValue -= playerUnitStats.meterCost;
        targetEnemy.TakeDamage(playerUnitStats.specialattack);
        Debug.Log("SPECIAL");
        bm.playerActionsMenu.SetActive(false);
        Invoke("CallTurnAfterDelay", 1f);
    }


    //Waits to call the StartNextTurn() method after 1 second has passed.
    public void CallTurnAfterDelay()
    {
        bm.StartNextTurn();
    }
}

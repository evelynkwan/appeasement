using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //VARIABLES//

    //REFERENCES//
    private UnitStats playerUnitStats;
    private int guardBoost;

    private BattleManager bm;
    private BattleUI bui;
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
        playerUnitStats.health -= (damageAmount - guardBoost);

        if (playerUnitStats.health <= 0)
        {
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
        if (bui.meterValue < 8)
        {
            bui.meterValue += playerUnitStats.meterRate;
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

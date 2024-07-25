using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //VARIABLES//

    //REFERENCES//
    private UnitStats playerUnitStats;

    private BattleManager bm;
    // Start is called before the first frame update
    void Start()
    {
        playerUnitStats = GetComponent<UnitStats>();
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        playerUnitStats.health -= damageAmount;

        if (playerUnitStats.health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("DED LMAO");
        }
    }

    public void Attack(EnemyAction targetEnemy)
    {
        targetEnemy.TakeDamage(playerUnitStats.attack);
        Debug.Log("TAKEN DAMAGE");
        bm.playerActionsMenu.SetActive(false);
        Invoke("CallTurnAfterDelay", 1f);
    }

    public void Defend()
    {

    }

    public void Special()
    {

    }


    //Waits to call the StartNextTurn() method after 1 second has passed.
    public void CallTurnAfterDelay()
    {
        bm.StartNextTurn();
    }
}

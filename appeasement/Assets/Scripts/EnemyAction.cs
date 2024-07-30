using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAction : MonoBehaviour
{

    //VARIABLES//

    //REFERENCES//
    private UnitStats enemyUnitStats; //reference to own Unit stats 

    private BattleManager bm;

    // Start is called before the first frame update
    void Start()
    {
        enemyUnitStats = GetComponent<UnitStats>();
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        if ((damageAmount - enemyUnitStats.defense) >= 1)
        {
            enemyUnitStats.health -= (damageAmount - enemyUnitStats.defense);
        }
        else
        {
            enemyUnitStats.health -= 1;
        }
        enemyUnitStats.health -= (damageAmount - enemyUnitStats.defense);

        //When this enemy dies, 
        //Set the current enemy to be the next enemy in the list until it reaches the end of the list.
        if (enemyUnitStats.health <= 0)
        {
            bm.curEnemy++;
            this.gameObject.SetActive(false);
            Debug.Log("DED LMAO");
        }
    }

    public void Attack(PlayerAction targetPlayer)
    {
        targetPlayer.TakeDamage(enemyUnitStats.attack);
        Debug.Log("TAKEN DAMAGE");
        Invoke("CallTurnAfterDelay", 1f);
    }

    //Waits to call the StartNextTurn() method after 1 second has passed.
    public void CallTurnAfterDelay()
    {
        bm.StartNextTurn();
    }
}

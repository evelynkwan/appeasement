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
    private BattleUI bui;
    private Audio audioo;

    // Start is called before the first frame update
    void Start()
    {
        enemyUnitStats = GetComponent<UnitStats>();
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        bui = GameObject.Find("Canvas").GetComponent<BattleUI>();
        audioo = GameObject.Find("SoundEffects").GetComponent<Audio>();
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
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
        //When this enemy dies, 
        //Set the current enemy to be the next enemy in the list until it reaches the end of the list.
        if (enemyUnitStats.health <= 0)
        {
            Invoke("NormalColor", 0.1f);
            bm.curEnemy++;
            this.gameObject.SetActive(false);
            Debug.Log("DED LMAO");
        }
        else
        {
            Invoke("NormalColor", 0.1f);
        }
    }

    public void NormalColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Attack(PlayerAction targetPlayer)
    {
        if (bm.enemies[bm.curEnemy] == bui.Dog)
        {
            bui.cannon.SetActive(true);
        }
        else if (bm.enemies[bm.curEnemy] == bui.Something) {
            bui.hammer.SetActive(true);
        }
        else if (bm.enemies[bm.curEnemy] == bui.Angy)
        {
            bui.bubble.SetActive(true);
        }
        else if (bm.enemies[bm.curEnemy] == bui.God)
        {
            bui.ribbon.SetActive(true);
        }
        audioo.PlaySEEnemy(bm.enemies[bm.curEnemy]);
        targetPlayer.TakeDamage(enemyUnitStats.attack);
        Debug.Log("TAKEN DAMAGE");
        Invoke("CallTurnAfterDelay", 1f);
    }

    //Waits to call the StartNextTurn() method after 1 second has passed.
    public void CallTurnAfterDelay()
    {
        bui.cannon.SetActive(false);
        bui.hammer.SetActive(false);
        bui.bubble.SetActive(false);
        bui.ribbon.SetActive(false);
        bm.StartNextTurn();
    }
}

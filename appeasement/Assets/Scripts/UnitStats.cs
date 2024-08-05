using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public int health;
    public int max_health;
    public int attack;
    public int defense;
    public float speed;
    public int guardAmount;
    public int meterCost;
    public int meterRate;
    public int specialattack;
    public bool dead = false;
    private bool first = true;
    private BattleManager bm;
    // Start is called before the first frame update

    void Start()
    {
        bm = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        if (first)
        {
            bm.Retry();
            first = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

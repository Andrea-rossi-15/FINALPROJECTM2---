using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

public class m1ProjectTest : MonoBehaviour
{
    public Hero Hero_a;
    public Hero Hero_b;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Hero_a.IsAlive() || !Hero_b.IsAlive()) { return; }

        Hero firstAttacker;
        Hero secondAttacker;

        if (Hero_a.GetBaseStats().spd > Hero_b.GetBaseStats().spd)
        {
            firstAttacker = Hero_a;
            secondAttacker = Hero_b;
        }
        else
        {
            firstAttacker = Hero_b;
            secondAttacker = Hero_a;
        }

        Attack(firstAttacker, secondAttacker);

        if (secondAttacker.IsAlive())
        {
            Attack(secondAttacker, firstAttacker);
        }
        Debug.Log(firstAttacker);
    }

    public void Attack(Hero attacker, Hero defender)
    {


        if (GameFormulas.HasHit(attacker.GetBaseStats(), defender.GetBaseStats()))
        {
            if (GameFormulas.HasElementAdvantage(attacker.GetWeapone().GetElem(), defender))
            {
                Debug.Log("WEAKNESS");
            }


            if (GameFormulas.HasElementAdvantage(attacker.GetWeapone().GetElem(), defender))
                Debug.Log("RESIST");

            int damage = GameFormulas.CalculateDamage(attacker, defender);
            defender.TakeDamage(damage);
            Debug.Log($"{attacker.Getname()} has hit {damage} of damage");

            if (!defender.IsAlive())
            {
                Debug.Log($"{attacker.Getname()} has won!");
            }
        }
    }


}

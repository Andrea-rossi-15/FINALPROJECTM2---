using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class HeroScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

[Serializable]
public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private Element resistance;
    [SerializeField] private Element weakness;
    [SerializeField] private Weapone weapone;

    public Hero(string name, int hp, Stats baseStats, Element resistance, Element weakness, Weapone weapone)
    {
        this.name = name;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapone = weapone;
    }

    public string Getname() => name;
    public int GetHp() => hp;
    public Stats GetBaseStats() => baseStats;
    public Element GetResistance() => resistance;
    public Element GetWeakness() => weakness;
    public Weapone GetWeapone() => weapone;


    public void Setname(string valore) => name = string.IsNullOrEmpty(valore) ? (valore = null) : name = valore;
    public void SetHp(int valore) => hp = (valore < 0) ? (valore = 0) : hp = valore;



    public void AddHp(int amount)
    {
        SetHp(hp + amount);
    }


    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    public bool IsAlive()
    {
        if (hp > 0)
        {
            return true;
        }
        return false;

    }
}

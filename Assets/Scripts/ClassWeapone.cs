
using UnityEngine;

[System.Serializable]
public class Weapone
{
    public enum DamageType
    {
        Physical,
        Magical,
    }
    [SerializeField] private string Name;
    [SerializeField] private DamageType dmgType;
    [SerializeField] private Element elem;
    [SerializeField] private Stats bonusStats;

    public Weapone(string Name, DamageType dmgType, Element elem, Stats bonusStats)
    {
        this.Name = Name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }

    public string GetName() => Name;
    public DamageType GetDamage() => dmgType;
    public Element GetElem() => elem;
    public Stats GetBonusStats() => bonusStats;

}

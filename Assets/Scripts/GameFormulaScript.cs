
using UnityEngine;

public class GameFormulaScript : MonoBehaviour
{ }

[System.Serializable]
static class GameFormulas
{

    public static bool HasElementAdvantage(Element attackElement, Hero defender)
    {
        if (attackElement == defender.GetWeakness())
        {
            return true;
        }
        return false;
    }

    public static bool HasElementDisadvantaged(Element attackElement, Hero defender)
    {
        if (attackElement == defender.GetResistance())
        {
            return true;
        }
        return false;
    }

    public static float EvaluateElementModifier(Element attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
        {
            return 1.5f;
        }
        if (HasElementDisadvantaged(attackElement, defender))
        {
            return 0.5f;
        }
        return 1f;
    }

    [SerializeField]
    public static bool HasHit(Stats attacker, Stats defender)
    {
        int HitChance;
        HitChance = defender.eva - attacker.aim;
        int i;
        i = Random.Range(0, 99);

        if (i > HitChance)
        {
            Debug.Log("MISS");
            return true;

        }
        return false;
    }

    public static bool IsCritic(int critValue)
    {
        int i;
        i = Random.Range(0, 99);
        if (i < critValue)
        {
            Debug.Log("CRIT");
            return true;

        }
        return false;
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {


        Stats sumattackerStats = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapone().GetBonusStats());
        Stats sumdefenderstats = Stats.Sum(defender.GetBaseStats(), defender.GetWeapone().GetBonusStats());

        int GetTypeDam = 0;

        if (attacker.GetWeapone().GetDamage() == Weapone.DamageType.Physical)
        {


            GetTypeDam = defender.GetBaseStats().def;

        }
        else if (attacker.GetWeapone().GetDamage() == Weapone.DamageType.Magical)
        {


            GetTypeDam = defender.GetBaseStats().res;
        }

        int baseDamage = sumattackerStats.atk - GetTypeDam;

        float DamageMolt = baseDamage * EvaluateElementModifier(attacker.GetWeapone().GetElem(), defender);

        if (IsCritic(baseDamage) == true)
        {
            baseDamage = baseDamage * 2;
        }

        return baseDamage;
    }





}

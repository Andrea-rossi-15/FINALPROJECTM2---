using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct Stats
{
    public int atk, def, res, spd, crt, aim, eva;

    [SerializeField]
    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }
    public static Stats Sum(Stats a, Stats b)
    {
        Stats c = new Stats();
        c.atk = a.atk + b.atk;
        c.def = a.def + b.def;
        c.res = a.res + b.res;
        c.spd = a.spd + b.spd;
        c.crt = a.crt + b.crt;
        c.aim = a.aim + b.aim;
        c.eva = a.eva + b.eva;
        return c;
    }




}
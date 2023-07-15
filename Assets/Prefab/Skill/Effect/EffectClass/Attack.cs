using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Effect
{

    public void Apply(Character[] targets, float val)
    {
        foreach (Character chr in targets)
        {
            chr.TakeDamage(val);
        }
    }
}

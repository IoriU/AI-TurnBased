using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : Skill
{
    public EnergyManager energyManager;

    public override void Start()
    {
        energyManager = GetComponentInParent<EnergyManager>();
    }

    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        energyManager.ResetEnergy();
    }

}

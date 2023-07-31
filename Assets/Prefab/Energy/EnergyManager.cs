using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public int burstMaxEnergy;
    public int burstEnergy;

    public bool IsAvailable()
    {
        return burstEnergy >= burstMaxEnergy;
    }

    public void ResetEnergy()
    {
        burstEnergy = 0;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Status Effect")]
public class StatusEffect : MonoBehaviour
{
    public int atk = 0;
    public int def = 0;
    public int dot = 0;
    public int speed = 0;
    public int speedBar = 0;
    public int critRate = 0;
    public int dodge = 0;

    public int duration = 3;
    public int currentDuration = 0;

    //Status Aneh ANeh
    public bool isStun = false;

    public void Destroy()
    {
        Destroy(this);
    }
    public void ResetValues()
    {
        currentDuration = 0;
    }
}

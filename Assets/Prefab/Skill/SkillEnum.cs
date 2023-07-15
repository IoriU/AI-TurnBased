using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnum : MonoBehaviour
{
    public enum Type
    {
        Damage,
        Heal,
        AtkUp,
        AtkDown,
        DefUp,
        DefDown,
        SpeedUp,
        SpeedDown,
        Bleed
    }

    public enum Target
    {
        Self,
        Ally,
        Enemy
        
    }

    public enum TargetType
    {
        Base,
        Front,
        One,
        OneRandom,
        All,
        Custom
    }
}

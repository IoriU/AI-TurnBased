using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffectting
{
    public void ApplyEffect(StatusEffect effect);
    public void RemoveEffect(StatusEffect effect);
    public void HandleEffect();
    
}

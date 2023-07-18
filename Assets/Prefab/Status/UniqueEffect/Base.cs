using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UniqueEffect
{
    public class Base : MonoBehaviour
    {
        
        public virtual void SetupTrigger(Character.Base chara) { }
        public virtual void OnTrigger(Character.Base chara) { }
        
    }

}

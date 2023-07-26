using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Fencer : Path
    {

        //[HideInInspector]
        public int target;
        //[HideInInspector]
        public int maxHit;
        //[HideInInspector]
        public int curHit;
        public bool ignoreS2;

        private void Start()
        {
            target = -1;
            maxHit = 3;
            curHit = 1;
            ignoreS2 = false;
        }

        



    }

}

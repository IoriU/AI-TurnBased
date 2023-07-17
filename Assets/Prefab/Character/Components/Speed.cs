using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Speed : MonoBehaviour
    {
        //Speed prop
        public float speed; //Initial / base speed from character
        private float curSpeed; //Dynamic stat of defence
                                //Bagian dari prop speed yang nentuin dia bakal jalan di turn tersebut atau tidak,
                                //Ex, bila speedBar lebih dari 100, maka chara tersebut akan jalan.
        
        public float speedBar;
        public ProgressBar speedBarObj; //For UI Purpose
        public float barRatio;

        
        // Start is called before the first frame update
        void Start()
        {
            curSpeed = speed;
            speedBarObj.InitValue(100);
        }

        //Update character SpeedBar tiap turn selesai, nanti dipanggil di GameController
        //Interval parameter untuk getGameDeltaTime
        public void UpdateSpeedBar(float interval)
        {
            speedBar += curSpeed * interval * barRatio;
            speedBarObj.UpdateVal(speedBar);
        }

        public void NextTurn()
        {
            speedBar = 0;
            speedBarObj.UpdateVal(speedBar);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadingManager : MonoBehaviour
{
    public LoadingToStage ltc;
        public void OnClickBox()
        {
            string nowbutton = EventSystem.current.currentSelectedGameObject.name;
            if (nowbutton == "Stage1") ltc.startStageNum = 1;
            else if (nowbutton == "Stage2") ltc.startStageNum = 2;
            else if (nowbutton == "BossStage") ltc.startStageNum = 3;

            if (ltc.startStageNum != 0) ltc.call();
        }
    
}
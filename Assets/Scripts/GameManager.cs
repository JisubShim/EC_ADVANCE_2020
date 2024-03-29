﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    
    void Awake()
    {
        talkPanel.SetActive(false);
    }
    public void Action(GameObject scanObj)
    {
            isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
            talkPanel.SetActive(isAction);
    }
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
            talkText.text = talkData;

        isAction = true;
        talkIndex++;
    }
}

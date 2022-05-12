using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public Level level;
    // Start is called before the first frame update
    void Start()
    {
        level = new Level(1, OnLevelUp);
    }

    public void OnLevelUp()
    {
        Debug.Log("Leveled Up");
        int oldEXP = level.experience;
        int newEXP = level.GetXPForLevel(level.currentLevel);
        level.experience = 0;
        level.experience = (oldEXP - newEXP);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ExpText>().UpdateEXP();
        GameManager.instance.LevelUpOn();
    }
}

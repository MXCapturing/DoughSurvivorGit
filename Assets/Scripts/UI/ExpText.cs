using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpText : MonoBehaviour
{
    public Slider expBox;
    private PlayerExp playerExp;

    public float minEXP;
    public float maxEXP;
    public float expPercentage;

    private void Start()
    {
        playerExp = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerExp>();
        UpdateEXP();
    }
    // Update is called once per frame
    private void Update()
    {
        expPercentage = playerExp.level.experience;
        Debug.Log(expPercentage);
        //Lurp this so it's smoother animation
        expBox.value = expPercentage;
    }

    public void UpdateEXP()
    {
        maxEXP = playerExp.level.GetEXPRequired(playerExp.level.currentLevel + 2);
        Debug.Log(maxEXP);
        expBox.maxValue = maxEXP;
    }
}

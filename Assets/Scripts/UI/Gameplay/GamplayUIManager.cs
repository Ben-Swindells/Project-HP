using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GamplayUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image healthBarFill;
    public Image EXPbarFill;
    public Image StaminaBarFill;
    public TMP_Text levelText;

    [Header("Required Scripts")]
    public PlayerManager playerScript;
    public Enemy enemyScript;

    private int exp;
    private int level;
    private int[] maxExp = new int[] { 100, 140, 160, 180, 240, 300, 420 };
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage()
    {
        
    }
    private void SetLevelNumber(int levelNumber)
    {

        levelText.text = (levelNumber + 1).ToString() ;
    }
    private void GiveEXP(float expNormalized)
    {

        EXPbarFill.fillAmount = expNormalized;
    }
    public void AddExperience(int expAdd)
    {
        exp += expAdd;
        Debug.Log(exp);
        GiveEXP(GetExpNormalized());


        if (!isMaxLevel())
        {
  
            while (!isMaxLevel() && exp >= GetMaxExperienceLevel(level))
            {

                
                
                exp -= GetMaxExperienceLevel(level);
                level++;
                SetLevelNumber(level);
                GiveEXP(GetExpNormalized());
                Debug.Log(GetMaxExperienceLevel(level));
                Debug.Log(exp);
                break;
            }

        } else
        {
            Debug.Log("PLAYER IS MAX");
        }



    }
    public float GetExpNormalized()
    {
        if(isMaxLevel())
        {
            return 1f;
        } else
        {
            return (float)exp / GetMaxExperienceLevel(level);
        }
       
    }
    public int GetMaxExperienceLevel(int level)
    {
        if(level < maxExp.Length)
        {
            return maxExp[level];
        } else
        {
            Debug.Log("MAX LEVEL");
            return 100;
        }
    }
    public bool isMaxLevel()
    {
        return isMaxLevel(level);
    }
    public bool isMaxLevel(int level)
    {
        return level == maxExp.Length - 1;
    }

    public void StaminaDrain()
    {

    }
}

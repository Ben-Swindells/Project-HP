using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class LevelingAnimation
{
    public event EventHandler OnExpChanged;
    public event EventHandler OnLevelChanged;

    private static readonly int[] experiencePerLevel = new[] { 100, 120, 140, 160, 180, 200, 220, 240, 260, 300 };

    private LevelSystem levelSystem;
    private bool isAnimating;
    private float updateTimer;
    private float updateTimerMax;

    private int level;
    private int exp;
    public LevelingAnimation()
    {
        level = 0;
        exp = 0;
        updateTimerMax = .016f;
        FunctionUpdater.Create(() => Update());
    }
    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        level = GetLevelNumber();
        exp = GetExperience();

        levelSystem.OnExperienceChanged += LevelSystem_OnExpChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }
    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        isAnimating = true;
    }
    private void LevelSystem_OnExpChanged(object sender, System.EventArgs e)
    {
        isAnimating = true;
    }
    private void Update()
    {
        if (isAnimating)
        {
            updateTimer += Time.deltaTime;
            while (updateTimer > updateTimerMax)
            {
                updateTimer -= updateTimerMax;
                UpdateTypeAndExperience();
            }
        }
        Debug.Log(level + " " + exp);
       
    }
    public void addExp(int amount)
    {
        if (!IsMaxLevel())
        {
            exp += amount;
            while (!IsMaxLevel() && exp >= GetExperienceToNextLevel(level))
            {
                exp -= GetExperienceToNextLevel(level);
                level++;
                if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
            }
            if (OnExpChanged != null) OnExpChanged(this, EventArgs.Empty);
        }

    }
    private void UpdateTypeAndExperience()
    {
        if (level < GetLevelNumber())
        {
            AddExp();
        }
        else
        {
            //Local Level Equals the target
            if (exp < GetExperience())
            {
                AddExp();
            }
            else
            {
                isAnimating = false;
            }
        }
    }
    private void AddExp()
    {
        exp++;
        
        if (exp >= GetExperienceToNextLevel(level))
        {
            level++;
          
            exp = 0;

        }

    }

    public int GetExperience()
    {
        return exp;
    }
    public bool IsMaxLevel()
    {
        return IsMaxLevel(level);
    }
    public bool IsMaxLevel(int level)
    {
        return level == experiencePerLevel.Length - 1;
    }
    public int GetLevelNumber()
    {
        return level;
    }
    public float GetExpNormalized()
    {
        if (IsMaxLevel())
        {
            return 1f;
        }
        else
        {
            return (float)exp / GetExperienceToNextLevel(level);
        }

    }
    public int GetExperienceToNextLevel(int level)
    {
        Debug.Log(level);
        if (level < experiencePerLevel.Length)
        {
            return experiencePerLevel[level];
        }
        else
        {
            Debug.LogError("Level Invalid" + level);
            return 100;
        }

    }
}

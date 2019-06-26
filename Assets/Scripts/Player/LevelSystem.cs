using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem {

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int level;
    private int experience;
    private int experienceToNextLevel;


    public LevelSystem()
    {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        if(experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
            if (OnLevelChanged != null) OnLevelChanged(this, System.EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, System.EventArgs.Empty);
        Debug.Log(level + " " + experience);
    }
    public int GetLevelNumber()
    {
        return level;
    }
    public float GetExperienceNormalized()
    {
        return (float)experience / experienceToNextLevel;
    }
}

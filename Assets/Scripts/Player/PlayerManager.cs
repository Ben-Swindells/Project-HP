using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{


    [SerializeField]  public static string playerName;
    [SerializeField]  public static bool male;
    [SerializeField]  public static bool female;

    private LevelSystem levelSystem;

    public int playerHP;
    public int playerDPS;
    private int playerLevel;

    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
    }


}

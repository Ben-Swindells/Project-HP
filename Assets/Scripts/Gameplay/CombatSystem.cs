using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour {

    [Header("Required Scripts")]
    public PlayerManager player;
    public Enemy enemy;
    public GamplayUIManager gameplayUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int  dealDamage(int health, int damage)
    {
        return health -= damage;
    }

}

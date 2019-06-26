using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Stats
    [Header("Enemy Statistics")]
    public int health;
    public string enemyName;
    public int baseAttack;
    public float speed;
    public int enemyExp;

    [Header("Enemy AI Values")]
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform basePosition;

    [Header("Required Scripts")]
    [SerializeField] private PlayerManager player;
    [SerializeField] private GamplayUIManager levelSet;

    //private LevelSystem levelSystem;

    private void Awake()
    {
    
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int dmg)
    {
        health -= dmg;
        if(health == 0)
        {
            levelSet.AddExperience(140);
            Destroy(this.gameObject);
        }
     

    }

    void Leveling(int exp)
    {
   
        
      

    }
    void EnemyAttack()
    {

    }
}

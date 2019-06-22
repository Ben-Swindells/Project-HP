using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    //Collect Scripts
    private Enemy enemy;
    private PlayerManager player;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindObjectOfType<Enemy>();
        player = GameObject.FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("breakable"))
        {
            collision.GetComponent<pot>().isDestroy();
        }
        if(collision.CompareTag("enemy"))
        {
            enemy.health = enemy.health - player.playerDPS;
            enemy.EnemyDeath(collision.gameObject);
            
        }
    }
}

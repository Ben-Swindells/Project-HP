using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float knockbackForce;
    public float knockTime;

    //Taking damage
    private Renderer rend;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
  
            if (collision.gameObject.CompareTag("enemy"))
        {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockbackForce;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy, collision.gameObject));
           
        }
        }
    }
    private IEnumerator KnockCo(Rigidbody2D enemy, GameObject coll)
    {
        if(enemy != null)
        {
            rend = coll.GetComponent<Renderer>();
            rend.material.color = Color.red;
            yield return new WaitForSeconds(knockTime);
            if (enemy != null)
               {
                enemy.velocity = Vector2.zero;
                enemy.isKinematic = true;
                rend.material.color = Color.white;
            }

        }
    }
}

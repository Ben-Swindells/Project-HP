using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float knockbackForce;
    public float knockTime;

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
                StartCoroutine(KnockCo(enemy));
           
        }
        }
    }
    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            if (enemy != null)
               {
                enemy.velocity = Vector2.zero;
                enemy.isKinematic = true;
            }

        }
    }
}

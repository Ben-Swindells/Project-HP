using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState //State System
{
    walk,
    attack,
    interact,
}
 
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public PlayerState currentState;

    private Vector3 change;
    private Rigidbody2D myRigidbdy;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        myRigidbdy = GetComponent<Rigidbody2D>();
        anim.SetFloat("moveX", 0);
        anim.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetMouseButton(0) && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk)
        {
            UpdateAnimationMove();
        }
       
    }
    private IEnumerator AttackCo()
    {
        anim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    void UpdateAnimationMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);
            
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        change.Normalize();
        myRigidbdy.MovePosition(
            transform.position + change * moveSpeed * Time.deltaTime
        );
    }
}

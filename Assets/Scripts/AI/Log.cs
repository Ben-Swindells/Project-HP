using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //Locates player
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}

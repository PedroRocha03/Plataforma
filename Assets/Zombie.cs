using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Zombie : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
       
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards
                (transform.position, new Vector2(PlayerController.Instance.transform.position.x, transform.position.y), speed * Time.deltaTime);
    }
    public override void EnemyHit(float _damageDone)
    {
        base.EnemyHit(_damageDone);
    }

}

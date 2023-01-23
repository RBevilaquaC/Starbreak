using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMoviment : EnemyBasicMovements
{
    private void Update()
    {
        if(timerCDShoot <= 0)
        {
            //RequestShoot();
            timerCDShoot = cdShoot;
        }
        else if (timerCDShoot >= 0) timerCDShoot -= Time.deltaTime;
    }

    
    private void FixedUpdate()
    {
        lookToPlayer();
        if(DirToPlayer() > distToStay)
            MoveFoward();
        else MoveToSide();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerMoviment : EnemyBasicMovements
{
    private void FixedUpdate()
    {
        lookToPlayer();
    }
}

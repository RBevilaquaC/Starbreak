using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMoviment : EnemyBasicMovements
{
    private void FixedUpdate()
    {
        lookToPlayer();
        MoveFoward();
    }
}

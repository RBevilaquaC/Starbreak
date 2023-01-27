using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeSystem : LifeSystem
{
    [SerializeField] private Slider lifeBar;

    public override void takeDamage(int damgeAmount)
    {
        base.takeDamage(damgeAmount);
        UpdateLifeBar();
        Camera.main.GetComponent<ShakeCamera>();

    }

    private void UpdateLifeBar()
    {
        lifeBar.value = (float)(currentLife)/maxLife;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpButtons : MonoBehaviour
{
    public void DamageUp()
    {
        Character.instance.Damage.AddModifier(new StatModifier(1f, StatModType.Flat));
        GameManager.instance.LevelUpOff();
    }
    public void SpeedUp()
    {
        Character.instance.Speed.AddModifier(new StatModifier(1f, StatModType.Flat));
        GameManager.instance.LevelUpOff();
    }

    public void FireRateUp()
    {
        Character.instance.FireRate.AddModifier(new StatModifier(-.005f, StatModType.Flat));
        GameManager.instance.LevelUpOff();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour, IDamageable
{
    public int health;
    public int Health { get =>Health; set => health = value; }

    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //You Lose
        }
    }
}

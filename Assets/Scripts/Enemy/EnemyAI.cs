using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public int _health;
    
    public int Health
    {
        get => Health;
        set => _health = value;
    }

    public void Damage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

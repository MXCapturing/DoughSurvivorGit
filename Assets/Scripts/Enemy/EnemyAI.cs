using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public float speed;
    public int _health;
    GameObject target;
    public float targetDistance;
    Rigidbody2D _rb;

    public int damage;
    public float timeBetweenDamage;
    float damageTimer;

    public int expValue;

    public Slider hpBar;
    
    public int Health
    {
        get => Health;
        set => _health = value;
    }

    public void Damage(int damage)
    {
        _health -= damage;
        hpBar.value = _health;
        Flicker();
        if(_health <= 0)
        {
            //Character.instance.Exp.AddModifier(new StatModifier(expValue, StatModType.Flat));
            GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerExp>().level.AddExp(expValue);
            Destroy(this.gameObject);
        }
    }

    void Flicker()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("FlickOff", 0.1f);
    }

    void FlickOff()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Start()
    {
        targetDistance = 3.75f;
        _rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Core");
        damageTimer = timeBetweenDamage;
        hpBar.maxValue = _health;
        hpBar.value = _health;
    }

    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, target.transform.position) > targetDistance)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            _rb.MovePosition(newPosition);
        }
        else
        {
            DoDamage();
        }
    }

    void DoDamage()
    {
        damageTimer -= Time.deltaTime;
        if (damageTimer <= 0)
        {
            target.GetComponent<IDamageable>().Damage(damage);
            damageTimer = timeBetweenDamage;
            Debug.Log(transform.name + " Damage: " + damage);
        }
    }
}

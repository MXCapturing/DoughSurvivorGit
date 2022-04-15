using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour, IBullets
{
    public float travelDistance;
    public int damage;
    public float travelTime;
    float travelSpeed;

    public int pierceNumber;

    public float TravelDistance {get => TravelDistance; set => travelDistance = value; }
    public int Damage { get => Damage; set => damage = value; }
    public float TravelTime { get => TravelTime; set => travelTime = value; }


    // Start is called before the first frame update
    void Start()
    {
        travelSpeed = travelDistance / travelTime;
        Invoke("Destroy", travelTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * travelSpeed * Time.deltaTime);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            IDamageable hit = col.GetComponent<IDamageable>();
            if(hit != null)
            {
                hit.Damage(damage);
                pierceNumber--;
                if(pierceNumber <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}

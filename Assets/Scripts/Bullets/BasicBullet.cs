using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float travelDistance;
    public int damage;
    public float travelTime;
    float travelSpeed;


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
            
        }
    }
}

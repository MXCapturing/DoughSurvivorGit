using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float fireRate;
    float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(fireTimer <= 0)
            {
                Debug.Log("LeftClick");
                fireTimer = fireRate;
            }
        }

        if(fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
    }
}

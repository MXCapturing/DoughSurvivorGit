using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float fireRate;
    float fireTimer;
    public GameObject bullet;

    float offset;
    public float offsetMax;
    public float offsetIncreaseRate;
    public float offsetDecreaseRate;
    public float straightShotTimer;

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
            OffsetUp();
            if(fireTimer <= 0)
            {
                Debug.Log("LeftClick");
                float offsetRand = Random.Range(-offset, offset);
                Quaternion offsetShot = Quaternion.Euler(0, 0, offsetRand);
                Instantiate(bullet, transform.position, transform.rotation * offsetShot);
                fireTimer = fireRate;
            }
        }
        else
        {
            OffsetDown();
        }

        if(fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
    }

    void OffsetUp()
    {
        if (offset < offsetMax)
        {
            offset += offsetIncreaseRate * Time.deltaTime;
        }
        else if (offset > offsetMax)
        {
            offset = offsetMax;
        }
    }

    void OffsetDown()
    {
        if (offset > 0)
        {
            offset -= offsetDecreaseRate * Time.deltaTime;
        }
        else if (offset < 0)
        {
            offset = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;

    public bool canMove;

    private float moveInputX;
    private float moveInputY;
    private float lastMoveInputX;
    private float lastMoveInputY;
    public float currentMoveSpeed;
    public float maxMoveSpeed;
    public float timeZeroToMax;
    public float timeMaxToZero;
    float decelRatePerSec;
    float accelRatePerSec;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        accelRatePerSec = maxMoveSpeed / timeZeroToMax;
        decelRatePerSec = -maxMoveSpeed / timeMaxToZero;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MoveUpdate();
        }
        accelRatePerSec = maxMoveSpeed / timeZeroToMax;
        decelRatePerSec = -maxMoveSpeed / timeMaxToZero;
    }

    void MoveUpdate()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");
        if(moveInputX != 0 || moveInputY != 0)
        {
            currentMoveSpeed += accelRatePerSec * Time.deltaTime;
            currentMoveSpeed = Mathf.Min(currentMoveSpeed, maxMoveSpeed);
            _rb.velocity = new Vector2(moveInputX * currentMoveSpeed, moveInputY * currentMoveSpeed);
            lastMoveInputX = moveInputX;
            lastMoveInputY = moveInputY;
        }
        else if(moveInputX == 0 && moveInputY == 0)
        {
            currentMoveSpeed += decelRatePerSec * Time.deltaTime;
            currentMoveSpeed = Mathf.Max(currentMoveSpeed, 0);
            _rb.velocity = new Vector2(lastMoveInputX * currentMoveSpeed, lastMoveInputY * currentMoveSpeed);
        }
    }
}

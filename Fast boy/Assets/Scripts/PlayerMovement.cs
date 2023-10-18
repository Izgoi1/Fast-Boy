using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform posCeneter;
    [SerializeField] Transform posLeft;
    [SerializeField] Transform posRight;
    [SerializeField] private float littleJumpForce;
    [SerializeField] private float jumpForce;

    private float time;
    private float sideSpeed = 10f;
    private bool isGround;
    private Rigidbody rb;
    private Vector3 pos;

    private int currentPos; // 0 = center, 1 = left, 2 = right

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGround = true;

    }
    private void Update()
    {
        if (currentPos == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentPos = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                currentPos = 2;
            }
        }
        else if(currentPos == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentPos = 0;
            }
        }
        else if(currentPos == 2)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentPos = 0;
            }
        }

        if (currentPos == 0)
        {
            if(Vector3.Distance(transform.position, new Vector3(posCeneter.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                pos = new Vector3(posCeneter.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(pos.normalized * sideSpeed * Time.deltaTime, Space.World);
            }
        }
        else if (currentPos == 1)
        {
            if (Vector3.Distance(transform.position, new Vector3(posLeft.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                pos = new Vector3(posLeft.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(pos.normalized * sideSpeed * Time.deltaTime, Space.World);
            }
        }
        else if (currentPos == 2)
        {
            if (Vector3.Distance(transform.position, new Vector3(posRight.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                pos = new Vector3(posRight.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(pos.normalized * sideSpeed * Time.deltaTime, Space.World);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isGround == false)
        {
            rb.velocity -= new Vector3(0, littleJumpForce, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isGround == true)
        {
            time = 0.75f;
            transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);
        }

        if (time <= 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if(time > 0)
        {
            time -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
    }
}


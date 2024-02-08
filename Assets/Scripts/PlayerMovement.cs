using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;

    private void Start()
    {
        transform.position = new Vector2(0f, -3.5f);
    }
    private void Update()
    {
        Shot();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") < 0 && transform.position.x > -4.2f)
        {
            moveVelocity = Vector3.left;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0 && transform.position.x < 4.2f)
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * moveSpeed * Time.fixedDeltaTime;
    }

    private void Shot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameManager.Instance.isShot)
            {
                Instantiate(GameManager.Instance.Bullet, GameManager.Instance.player.position, Quaternion.identity);
                GameManager.Instance.isShot = true;
            }
        }
    }
}

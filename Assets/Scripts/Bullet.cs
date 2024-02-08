using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Out"))
        {
            Destroy(gameObject);
            GameManager.Instance.isShot = false;
        }
    }
}

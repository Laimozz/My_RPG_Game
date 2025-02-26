using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    [SerializeField] private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        FlyToPlayer();
    }

    public void FlyToPlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Tính góc xoay

        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, bulletSpeed * Time.deltaTime);



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

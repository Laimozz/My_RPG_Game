
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPatrol : EnemyActions
{
    [SerializeField] private float speedPatrol;

    //[SerializeField] private Waypoint patrolPoints;

    [SerializeField] private Transform[] patrolPoints;

     private int currentIndex = 0;

     protected Vector2 lastPosition;
    SpriteRenderer spriteRenderer;

    [SerializeField] protected float checkInterval = 0.2f; // Thời gian kiểm tra mỗi 0.2s
    [SerializeField] protected float timer = 0f;

    private void Awake()
    {
        lastPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        FlipEnemy();
    }
    public override void Act()
    {
        //if(patrolPoints.Points.Length <=0 ) { return; }

        if (patrolPoints.Length <= 0) { return; }
        Patrol();
        

    }

    public void Patrol()
    {

        Vector2 targetPos = patrolPoints[currentIndex].position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speedPatrol * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            currentIndex = RandomPos();
        }
    }

    public int RandomPos()
    {
        if (patrolPoints.Length <= 0) return -1;

        int tmp = Random.Range(0, patrolPoints.Length);

        return tmp;
    }

    public virtual void FlipEnemy()
    {
        timer += Time.deltaTime;
        if (timer > checkInterval)
        {
            float movement = transform.position.x - lastPosition.x; // Tính toán sự thay đổi vị trí

            if (Mathf.Abs(movement) > 0.1f)
            { // Chỉ lật nếu di chuyển đủ xa
                spriteRenderer.flipX = movement > 0;
            }

            lastPosition = transform.position; // Luôn cập nhật vị trí mỗi frame
            timer = 0;
        }
    }
}

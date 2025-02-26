using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] LayerMask playerMask;
    [SerializeField] Transform attackPos;
    [SerializeField] float attackRadius;
    [SerializeField] float rangeToAttack;
    [SerializeField] float speedBoss;
    [SerializeField] float dameToPlayer;

    public Transform player;

    public bool isFlipped = false;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
        LookAtPlayer();
    }
    private void FixedUpdate()
    {
        ChaseToPlayer();
    }

    public void ChaseToPlayer()
    {
        float dis = Mathf.Abs(transform.position.x - player.transform.position.x);
        if(dis > rangeToAttack)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speedBoss * Time.fixedDeltaTime);
            rb.MovePosition(newPos);    
        }
        else
        {
            transform.GetComponent<BossAnimation>().AttackState();
        }
    }

    public void DealDame()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPos.position , attackRadius , playerMask);
        if(hit != null)
        {
            hit.GetComponent<PlayerHeath>().TakeDamage(dameToPlayer);
        }
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
}

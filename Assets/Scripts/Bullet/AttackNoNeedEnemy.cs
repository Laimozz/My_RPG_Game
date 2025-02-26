using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNoNeedEnemy : MonoBehaviour
{
    [SerializeField] public float dameOnSecond;

    [SerializeField] private float timeToDestroyObject;

    private Dictionary<Collider2D , float> timers = new Dictionary<Collider2D , float>(); 

    //private float timer;

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void Update()
    {
        //TimerDealDame();
    }
    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(timeToDestroyObject);

        Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (!timers.ContainsKey(other))
            {
                timers[other] = 0f;
            }

            timers[other] -= Time.deltaTime;

            if (timers[other] <= 0f)
            {
                timers[other] = 1f;
                other.GetComponent<EnemyHeath>().TakeDamage(dameOnSecond);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (timers.ContainsKey(other))
        {
            timers.Remove(other);
        }
    }

    //public void TimerDealDame()
    //{
    //    if(timer > 0)
    //    {
    //        timer -= Time.deltaTime;
    //    }
    //}
}

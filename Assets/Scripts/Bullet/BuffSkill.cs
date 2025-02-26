using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BuffSkill : MonoBehaviour
{
    [SerializeField] private float scaleDame;
    [SerializeField] private float timeEffectSkill;
    [SerializeField] private float damePlus;

    private void Start()
    {
        damePlus = PlayerCtrl.Instance.PlayerStats.damebasic * (1 + scaleDame);

        StartCoroutine(StartBuff());
    }
    public void Buff(float dame)
    {
        PlayerCtrl.Instance.PlayerStats.damebasic += dame;
    }

    IEnumerator StartBuff()
    {
        Buff(damePlus);

        yield return new WaitForSeconds(timeEffectSkill);

        Buff(-damePlus);
    }
}

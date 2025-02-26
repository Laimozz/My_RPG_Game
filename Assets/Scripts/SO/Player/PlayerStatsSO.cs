using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats" , menuName = "Players/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    [Header("Level")]
    [SerializeField] public int level;

    [Header("Heath")]
    [SerializeField] public float hp;
    [SerializeField] public float maxHp;

    [Header("Mana")]
    [SerializeField] public float mp;
    [SerializeField] public float maxMp;

    [Header("Protect")]
    [SerializeField] public float protect;

    [Header("Exp")]
    [SerializeField] public float currentExp;
    [SerializeField] public float nextLevelExp;
    [SerializeField] public float initialExp;
    [SerializeField , Range(1 , 2)] public float growthRateExp;

    [Header("Dame")]
    [SerializeField] public float damebasic;


    [Header("Potential")]
    [SerializeField] public float pointPotential;

    [SerializeField] public float sucManh;
    [SerializeField] public float phongThu;
    [SerializeField] public float theLuc;
    [SerializeField] public float chaka;

    [Header("Skill Points")]
    [SerializeField] public float skillPoint;

    [SerializeField] public float skill1;
    [SerializeField] public float skill2;
    [SerializeField] public float skill3;
    [SerializeField] public float skill4;
    [SerializeField] public float skill5;

    public void ResetStats()
    {
        hp = maxHp;

        mp = maxMp;

    }
}

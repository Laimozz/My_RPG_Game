using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillInfo" , menuName ="Skill Info")]
public class SkillInfo : ScriptableObject
{
    public GameObject skillPrefap;

    public float dealDame;

    public float comsumeMana;

    public float cooldownTime;
}

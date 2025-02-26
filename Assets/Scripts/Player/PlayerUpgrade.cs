using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private SkillInfo[] skillInfos;


    [SerializeField] private Image skill2;
    [SerializeField] private Sprite iconSkill2; 

    [SerializeField] private Image skill3;
    [SerializeField] private Sprite iconSkill3;

    [SerializeField] private Image skill4;
    [SerializeField] private Sprite iconSkill4;

    [SerializeField] private Image skill5;
    [SerializeField] private Sprite iconSkill5;

    private void Update()
    {
        if (skill2.sprite == null && PlayerCtrl.Instance.PlayerStats.skill2 > 0) 
        {
            skill2.sprite = iconSkill2;
            Color tmp = skill2.color;
            tmp.a = 1;
            skill2.color = tmp;
        }

        if (skill3.sprite == null && PlayerCtrl.Instance.PlayerStats.skill3 > 0)
        {
            skill3.sprite = iconSkill3;
            Color tmp = skill3.color;
            tmp.a = 1;
            skill3.color = tmp;
        }

        if (skill4.sprite == null && PlayerCtrl.Instance.PlayerStats.skill4 > 0)
        {
            skill4.sprite = iconSkill3;
            Color tmp = skill4.color;
            tmp.a = 1;
            skill4.color = tmp;
        }

        if (skill5.sprite == null && PlayerCtrl.Instance.PlayerStats.skill5 > 0)
        {
            skill5.sprite = iconSkill3;
            Color tmp = skill5.color;
            tmp.a = 1;
            skill5.color = tmp;
        }
    }

    public void StrengthStat()
    {
        if(PlayerCtrl.Instance.PlayerStats.pointPotential >= 5)
        {
            PlayerCtrl.Instance.PlayerStats.pointPotential -= 5;

            PlayerCtrl.Instance.PlayerStats.sucManh += 5;

            float tmp = PlayerCtrl.Instance.PlayerStats.damebasic * (float)(1 + 5 * 0.03);

            PlayerCtrl.Instance.PlayerStats.damebasic = Mathf.Ceil(tmp);
        }
    }

    public void DefenceStat()
    {
        if (PlayerCtrl.Instance.PlayerStats.pointPotential >= 5)
        {
            PlayerCtrl.Instance.PlayerStats.pointPotential -= 5;

            PlayerCtrl.Instance.PlayerStats.protect += 5;

            float tmp = (5f * PlayerCtrl.Instance.PlayerStats.level) / 3;

            PlayerCtrl.Instance.PlayerStats.protect = Mathf.Ceil(tmp);
        }
    }

    public void HeathStat()
    {
        if (PlayerCtrl.Instance.PlayerStats.pointPotential >= 5)
        {
            PlayerCtrl.Instance.PlayerStats.pointPotential -= 5;

            PlayerCtrl.Instance.PlayerStats.theLuc += 5;

            float tmp = PlayerCtrl.Instance.PlayerStats.maxHp * (float)(1 + 5 * 0.05);

            PlayerCtrl.Instance.PlayerStats.maxHp = Mathf.Ceil(tmp);

            PlayerCtrl.Instance.PlayerStats.hp = PlayerCtrl.Instance.PlayerStats.maxHp;
        }
    }

    public void ManaStat()
    {
        if (PlayerCtrl.Instance.PlayerStats.pointPotential >= 5)
        {
            PlayerCtrl.Instance.PlayerStats.pointPotential -= 5;

            PlayerCtrl.Instance.PlayerStats.chaka += 5;

            float tmp = PlayerCtrl.Instance.PlayerStats.maxMp * (float)(1 + 5 * 0.05);

            PlayerCtrl.Instance.PlayerStats.maxMp = Mathf.Ceil(tmp);

            PlayerCtrl.Instance.PlayerStats.mp = PlayerCtrl.Instance.PlayerStats.maxMp;
        }
    }

    public void Skill1()
    {
        if (PlayerCtrl.Instance.PlayerStats.skillPoint >= 1)
        {
            PlayerCtrl.Instance.PlayerStats.skillPoint -= 1;
            PlayerCtrl.Instance.PlayerStats.skill1 += 1;
            skillInfos[0].dealDame += PlayerCtrl.Instance.PlayerStats.skill1 * 10;
            skillInfos[0].comsumeMana = PlayerCtrl.Instance.PlayerStats.skill1;
        }
    }

    public void Skill2()
    {
        if (PlayerCtrl.Instance.PlayerStats.skillPoint >= 1 && PlayerCtrl.Instance.PlayerStats.level >=5)
        {
            PlayerCtrl.Instance.PlayerStats.skillPoint -= 1;
            PlayerCtrl.Instance.PlayerStats.skill2 += 1;
            skillInfos[1].dealDame += PlayerCtrl.Instance.PlayerStats.skill2 * 10;
            skillInfos[1].comsumeMana += PlayerCtrl.Instance.PlayerStats.skill2 * 2;
        }
    }

    public void Skill3()
    {
        if (PlayerCtrl.Instance.PlayerStats.skillPoint >= 1 && PlayerCtrl.Instance.PlayerStats.level >= 10)
        {
            PlayerCtrl.Instance.PlayerStats.skillPoint -= 1;
            PlayerCtrl.Instance.PlayerStats.skill3 += 1;
            skillInfos[2].dealDame += PlayerCtrl.Instance.PlayerStats.skill3 * 10;
            skillInfos[2].comsumeMana += PlayerCtrl.Instance.PlayerStats.skill3 * 3;
        }
    }

    public void Skill4()
    {
        if (PlayerCtrl.Instance.PlayerStats.skillPoint >= 1 && PlayerCtrl.Instance.PlayerStats.level >= 15)
        {
            PlayerCtrl.Instance.PlayerStats.skillPoint -= 1;
            PlayerCtrl.Instance.PlayerStats.skill4 += 1;
            skillInfos[3].dealDame += PlayerCtrl.Instance.PlayerStats.skill4 * 10;
            skillInfos[3].comsumeMana += PlayerCtrl.Instance.PlayerStats.skill4 * 4;
        }
    }

    public void Skill5()
    {
        if (PlayerCtrl.Instance.PlayerStats.skillPoint >= 1 && PlayerCtrl.Instance.PlayerStats.level >= 20)
        {
            PlayerCtrl.Instance.PlayerStats.skillPoint -= 1;
            PlayerCtrl.Instance.PlayerStats.skill5 += 1;

            skillInfos[4].comsumeMana += PlayerCtrl.Instance.PlayerStats.skill5 * 5;
        }
    }
}

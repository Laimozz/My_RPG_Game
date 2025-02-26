using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    //private float timerNormalAttack = 0f;
    //[SerializeField] private float timeToNormalAttack;

    //[SerializeField] private float dameByNormalAttack;

    //[SerializeField] private float disToEnemy;
   
    [SerializeField] private EnemyCtrl enemyCtrl;

    [SerializeField] private SkillInfo[] skillInfos;

    [SerializeField] private BoxCollider2D myFeet;

    [Header("Skill 0")]
    [SerializeField] private float timeSkill0 = 0;
    [SerializeField] private Image skill0Image;
    [SerializeField] private TextMeshProUGUI skill0Text;

    [Header("Skill1")]
    [SerializeField] private float timeSkill1 = 0;
    [SerializeField] private Image skill1Image;
    [SerializeField] private TextMeshProUGUI skill1Text;

    [Header("Skill2")]
    [SerializeField] private float timeSkill2 = 0;
    [SerializeField] private Image skill2Image;
    [SerializeField] private TextMeshProUGUI skill2Text;

    [Header("Skill3")]
    [SerializeField] private Transform posSkill3;

    [SerializeField] private float timeSkill3 = 0;
    [SerializeField] private Image skill3Image;
    [SerializeField] private TextMeshProUGUI skill3Text;

    [Header("Skill4")]
    [SerializeField] private Transform posSkill4;
    [SerializeField] private float scaleDamePlus;
    [SerializeField] private float damePlus;    
    [SerializeField] private float timeEffectSkill4;

    [SerializeField] private float timeSkill4 = 0;
    [SerializeField] private Image skill4Image;
    [SerializeField] private TextMeshProUGUI skill4Text;

    private void Awake()
    {
        myFeet = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        //Attack(); 
        if (PlayerCtrl.Instance.PlayerStats.hp <= 0) return;
        Timer();
        AttackNeedEnemy();
        AttackNoNeedEnemy();
    }

    public void AttackNeedEnemy()
    {
        if(skillInfos.Length <= 0 || enemyCtrl == null) return;

        if(Vector2.Distance(transform.position, enemyCtrl.transform.position) > 15f) return;

        //skill0
        if (Input.GetKeyDown(KeyCode.Alpha1) && timeSkill0 <= 0 &&
            PlayerCtrl.Instance.PlayerStats.mp >= skillInfos[0].comsumeMana)
        {
            AudioManager.Instance.PlayAttackSound();
            PlayerCtrl.Instance.PlayerAnimations.AttackNormal();
            GameObject skill = Instantiate(skillInfos[0].skillPrefap, transform.position + Vector3.right * 0.5f, Quaternion.identity);
            PlayerBullet playerBullet = skill.GetComponent<PlayerBullet>();
            if (playerBullet != null)
            {
                playerBullet.enemyCtrl = this.enemyCtrl;
                playerBullet.dameAmount = skillInfos[0].dealDame + PlayerCtrl.Instance.PlayerStats.damebasic;
            }
            else
            {
                Debug.Log("Error In PlayerAttack");
            }
            timeSkill0 = skillInfos[0].cooldownTime;
            PlayerCtrl.Instance.PlayerMana.UseMana(skillInfos[0].comsumeMana);
        }

        //skill1
        if (Input.GetKeyDown(KeyCode.Alpha2) && timeSkill1 <= 0 && 
            PlayerCtrl.Instance.PlayerStats.mp >= skillInfos[1].comsumeMana && PlayerCtrl.Instance.PlayerStats.skill2 > 0)
        {
            AudioManager.Instance.PlayAttackSound();
            PlayerCtrl.Instance.PlayerAnimations.AttackNormal();
            GameObject skill = Instantiate(skillInfos[1].skillPrefap ,transform.position + Vector3.right * 0.5f , Quaternion.identity);
            PlayerBullet playerBullet = skill.GetComponent<PlayerBullet>();
            if(playerBullet != null)
            {
                playerBullet.enemyCtrl = this.enemyCtrl;
                playerBullet.dameAmount = skillInfos[1].dealDame + PlayerCtrl.Instance.PlayerStats.damebasic;
            }
            else
            {
                Debug.Log("Error In PlayerAttack");
            }
            timeSkill1 = skillInfos[1].cooldownTime;
            PlayerCtrl.Instance.PlayerMana.UseMana(skillInfos[1].comsumeMana);
        }

        //skill2
        if (Input.GetKeyDown(KeyCode.Alpha3) && timeSkill2 <= 0 &&
            PlayerCtrl.Instance.PlayerStats.mp >= skillInfos[2].comsumeMana && PlayerCtrl.Instance.PlayerStats.skill3 > 0)
        {
            AudioManager.Instance.PlayAttackSound();
            PlayerCtrl.Instance.PlayerAnimations.AttackNormal();
            GameObject skill = Instantiate(skillInfos[2].skillPrefap, transform.position + Vector3.right * 0.5f, Quaternion.identity);
            PlayerBullet playerBullet = skill.GetComponent<PlayerBullet>();
            if (playerBullet != null)
            {
                playerBullet.enemyCtrl = this.enemyCtrl;
                playerBullet.dameAmount = skillInfos[2].dealDame + PlayerCtrl.Instance.PlayerStats.damebasic;
            }
            else
            {
                Debug.Log("Error In PlayerAttack");
            }
            timeSkill2 = skillInfos[2].cooldownTime;
            PlayerCtrl.Instance.PlayerMana.UseMana(skillInfos[2].comsumeMana);
        }

    }

    public void AttackNoNeedEnemy()
    {
        if (skillInfos.Length <= 0) return;

        //skill3
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && timeSkill3 <= 0 &&
            PlayerCtrl.Instance.PlayerStats.mp >= skillInfos[3].comsumeMana && PlayerCtrl.Instance.PlayerStats.skill4 > 0)
            {
                AudioManager.Instance.PlayAttackSound();
                PlayerCtrl.Instance.PlayerAnimations.AttackNormal();

                GameObject skill = Instantiate(skillInfos[3].skillPrefap, posSkill3.position, Quaternion.identity);

                skill.GetComponent<AttackNoNeedEnemy>().dameOnSecond = skillInfos[3].dealDame + 
                                                                       PlayerCtrl.Instance.PlayerStats.damebasic * 0.5f;

                timeSkill3 = skillInfos[3].cooldownTime;
                PlayerCtrl.Instance.PlayerMana.UseMana(skillInfos[3].comsumeMana);
            }
        }

        //skill4
        if (Input.GetKeyDown(KeyCode.Alpha5) && timeSkill4 <= 0 &&
            PlayerCtrl.Instance.PlayerStats.mp >= skillInfos[4].comsumeMana && PlayerCtrl.Instance.PlayerStats.skill5 > 0)
        {
            AudioManager.Instance.PlayAttackSound();
            PlayerCtrl.Instance.PlayerAnimations.AttackBuff();

            GameObject skill = Instantiate(skillInfos[4].skillPrefap, posSkill4.position, Quaternion.identity);
            skill.transform.SetParent(transform);

            damePlus = PlayerCtrl.Instance.PlayerStats.damebasic * this.scaleDamePlus;

            StartCoroutine(StartBuff(skill));

            timeSkill4 = skillInfos[4].cooldownTime;
            PlayerCtrl.Instance.PlayerMana.UseMana(skillInfos[4].comsumeMana);
        }
    }

    IEnumerator StartBuff(GameObject skill)
    {
        Buff(damePlus);

        yield return new WaitForSeconds(timeEffectSkill4);

        Buff(-damePlus);

        Destroy(skill); 
    }

    public void Buff(float dame)
    {
        PlayerCtrl.Instance.PlayerStats.damebasic += dame;
    }

    public void Timer()
    {
        //skill0
        skill0Image.fillAmount = Mathf.Lerp(skill0Image.fillAmount,
            timeSkill1 / skillInfos[0].cooldownTime, 10f * Time.deltaTime);
        skill0Text.text = $"{Mathf.Ceil(timeSkill0)}s";

        if (timeSkill0 > 0)
        {
            skill0Image.gameObject.SetActive(true);
            skill0Text.gameObject.SetActive(true);
            timeSkill0 -= Time.deltaTime;
        }
        else
        {
            timeSkill0 = 0f;
            skill0Image.gameObject.SetActive(false);
            skill0Text.gameObject.SetActive(false);
        }

        //skill1
        skill1Image.fillAmount = Mathf.Lerp(skill1Image.fillAmount,
            timeSkill1 / skillInfos[1].cooldownTime, 10f * Time.deltaTime);
        skill1Text.text = $"{Mathf.Ceil(timeSkill1)}s";

        if (timeSkill1 > 0)
        {
            skill1Image.gameObject.SetActive(true);
            skill1Text.gameObject.SetActive(true);
            timeSkill1 -= Time.deltaTime;
        }
        else
        {
            timeSkill1 = 0f;
            skill1Image.gameObject.SetActive(false);
            skill1Text.gameObject.SetActive(false);
        }

        // skill 2
        skill2Image.fillAmount = Mathf.Lerp(skill2Image.fillAmount,
            timeSkill2 / skillInfos[2].cooldownTime, 10f * Time.deltaTime);
        skill2Text.text = $"{Mathf.Ceil(timeSkill2)}s";
        if (timeSkill2 > 0)
        {
            skill2Image.gameObject.SetActive(true);
            skill2Text.gameObject.SetActive(true);
            timeSkill2 -= Time.deltaTime;
        }
        else
        {
            timeSkill2 = 0f;
            skill2Image.gameObject.SetActive(false);
            skill2Text.gameObject.SetActive(false);
        }

        //skill3
        skill3Image.fillAmount = Mathf.Lerp(skill3Image.fillAmount,
            timeSkill3 / skillInfos[3].cooldownTime, 10f * Time.deltaTime);
        skill3Text.text = $"{Mathf.Ceil(timeSkill3)}s";
        if (timeSkill3 > 0)
        {
            skill3Image.gameObject.SetActive(true);
            skill3Text.gameObject.SetActive(true);
            timeSkill3 -= Time.deltaTime;
        }
        else
        {
            timeSkill3 = 0f;
            skill3Image.gameObject.SetActive(false);
            skill3Text.gameObject.SetActive(false);
        }

        //skill4

        skill4Image.fillAmount = Mathf.Lerp(skill4Image.fillAmount,
            timeSkill4 / skillInfos[4].cooldownTime, 10f * Time.deltaTime);
        skill4Text.text = $"{Mathf.Ceil(timeSkill4)}s";
        if (timeSkill4 > 0)
        {
            skill4Image.gameObject.SetActive(true);
            skill4Text.gameObject.SetActive(true);
            timeSkill4 -= Time.deltaTime;
        }
        else
        {
            timeSkill4 = 0f;
            skill4Image.gameObject.SetActive(false);
            skill4Text.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        SelectionManage.OnEnemySelectedEvent += EnemySelectedCallBack;
        SelectionManage.OnNoSelectionEvent += NoSelectionCallBack;
    }

    private void OnDisable()
    {
        SelectionManage.OnEnemySelectedEvent -= EnemySelectedCallBack;
        SelectionManage.OnNoSelectionEvent -= NoSelectionCallBack;
    }

    private void EnemySelectedCallBack(EnemyCtrl enemyCtrlSelection)
    {
        enemyCtrl = enemyCtrlSelection;
    }
    private void NoSelectionCallBack()
    {
        enemyCtrl = null;
    }

    //public void Attack()
    //{
    //    if (enemyCtrl == null) { return; }

    //    if(timeToNormalAttack > 0f)
    //    {
    //        timerNormalAttack -= Time.deltaTime;
    //    }
    //    if(timerNormalAttack <= 0f) 
    //    {
    //        if (transform.position.x > enemyCtrl.transform.position.x && transform.localScale.x < 0)
    //        {
    //            if (Vector2.Distance(transform.position, enemyCtrl.transform.position) < disToEnemy)
    //            {
    //                if (Input.GetKeyDown(KeyCode.N))
    //                {
    //                    timerNormalAttack = timeToNormalAttack;
    //                    PlayerCtrl.Instance.PlayerAnimations.AttackState();
    //                    enemyCtrl.EnemyHeath.TakeDamage(dameByNormalAttack);

    //                }
    //            }
    //        }

    //        if (transform.position.x < enemyCtrl.transform.position.x && transform.localScale.x > 0)
    //        {
    //            if (Vector2.Distance(transform.position, enemyCtrl.transform.position) < disToEnemy)
    //            {
    //                if (Input.GetKeyDown(KeyCode.N))
    //                {
    //                    timerNormalAttack = timeToNormalAttack;
    //                    PlayerCtrl.Instance.PlayerAnimations.AttackState();
    //                    enemyCtrl.EnemyHeath.TakeDamage(dameByNormalAttack);
    //                }
    //            }
    //        }
    //    }    
    //}
}

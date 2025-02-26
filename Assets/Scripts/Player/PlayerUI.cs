using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : Singleton<PlayerUI>
{
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private Image heathImage;
    [SerializeField] private TextMeshProUGUI heathText;

    [SerializeField] private Image manaImage;
    [SerializeField] private TextMeshProUGUI manaText;

    [SerializeField] private Image expImage;
    [SerializeField] private TextMeshProUGUI expText;


    [Header("Potential")]
    [SerializeField] private TextMeshProUGUI pointPotentialText;
    [SerializeField] private TextMeshProUGUI sucManhText;
    [SerializeField] private TextMeshProUGUI phongThuText;
    [SerializeField] private TextMeshProUGUI theLucText;
    [SerializeField] private TextMeshProUGUI chakaText;

    [Header("CharacterInfo")]
    [SerializeField] private TextMeshProUGUI attackBaseStat;
    [SerializeField] private TextMeshProUGUI defenceBaseStat;
    [SerializeField] private TextMeshProUGUI heathBaseStat;
    [SerializeField] private TextMeshProUGUI manaBaseStat;

    [Header("CharacterSkill")]
    [SerializeField] private TextMeshProUGUI pointSkillText;
    [SerializeField] private TextMeshProUGUI skill1Text;
    [SerializeField] private TextMeshProUGUI skill2Text;
    [SerializeField] private TextMeshProUGUI skill3Text;
    [SerializeField] private TextMeshProUGUI skill4Text;
    [SerializeField] private TextMeshProUGUI skill5Text;

    [Header("CharacterEquipment")]
    [SerializeField] public Image weaponEquip;
    [SerializeField] public InventoryItems weaponItems;

    [SerializeField] public Image armorEquip;
    [SerializeField] public InventoryItems armorItems;

    [SerializeField] public Image pantEquip;
    [SerializeField] public InventoryItems pantItems;

    [SerializeField] public Image amuletEquip;
    [SerializeField] public InventoryItems amuletItems;

    [SerializeField] public Image glovesEquip;
    [SerializeField] public InventoryItems glovesItems;

    [SerializeField] public Image shoesEquip;
    [SerializeField] public InventoryItems shoesItems;

    void Update()
    {
        UpdateStats();

        UpdatePotential();

        UpdateSkill();

        UpdateCharacterInfo();
    }

    public void UpdateStats()
    {
        levelText.text = $"Level {PlayerCtrl.Instance.PlayerStats.level}";

        heathText.text = $"{PlayerCtrl.Instance.PlayerStats.hp} / {PlayerCtrl.Instance.PlayerStats.maxHp}";

        heathImage.fillAmount = Mathf.Lerp(heathImage.fillAmount, 
            PlayerCtrl.Instance.PlayerStats.hp / PlayerCtrl.Instance.PlayerStats.maxHp, 10f * Time.deltaTime);

        manaText.text = $"{PlayerCtrl.Instance.PlayerStats.mp} / {PlayerCtrl.Instance.PlayerStats.maxMp}";

        manaImage.fillAmount = Mathf.Lerp(manaImage.fillAmount ,
            PlayerCtrl.Instance.PlayerStats.mp / PlayerCtrl.Instance.PlayerStats.maxMp , 10f * Time.deltaTime);

        expText.text = $"{PlayerCtrl.Instance.PlayerStats.currentExp} / {PlayerCtrl.Instance.PlayerStats.nextLevelExp}";

        expImage.fillAmount = Mathf.Lerp(expImage.fillAmount , 
            PlayerCtrl.Instance.PlayerStats.currentExp / PlayerCtrl.Instance.PlayerStats.nextLevelExp , 10f * Time.deltaTime);
    }

    public void UpdatePotential()
    {
        pointPotentialText.text ="Điểm Tiềm Năng : " + PlayerCtrl.Instance.PlayerStats.pointPotential.ToString();
        sucManhText.text =PlayerCtrl.Instance.PlayerStats.sucManh.ToString();
        phongThuText.text = PlayerCtrl.Instance.PlayerStats.phongThu.ToString();
        theLucText.text = PlayerCtrl.Instance.PlayerStats.theLuc.ToString();
        chakaText.text = PlayerCtrl.Instance.PlayerStats.chaka.ToString(); 
    }

    public void UpdateSkill()
    {
        pointSkillText.text = "Điểm Kỹ Năng : "+PlayerCtrl.Instance.PlayerStats.skillPoint.ToString();

        skill1Text.text = PlayerCtrl.Instance.PlayerStats.skill1.ToString();
        skill2Text.text = PlayerCtrl.Instance.PlayerStats.skill2.ToString();
        skill3Text.text = PlayerCtrl.Instance.PlayerStats.skill3.ToString();
        skill4Text.text = PlayerCtrl.Instance.PlayerStats.skill4.ToString();
        skill5Text.text = PlayerCtrl.Instance.PlayerStats.skill5.ToString();
    }

    public void UpdateCharacterInfo()
    {
        attackBaseStat.text = PlayerCtrl.Instance.PlayerStats.damebasic.ToString();

        defenceBaseStat.text = PlayerCtrl.Instance.PlayerStats.protect.ToString();

        heathBaseStat.text = PlayerCtrl.Instance.PlayerStats.maxHp.ToString();

        manaBaseStat.text = PlayerCtrl.Instance.PlayerStats.maxMp.ToString();
    }

}

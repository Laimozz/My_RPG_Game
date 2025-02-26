

public class EnemyStats 
{
    public string nameEnemy;

    public int levelEnemy;

    public float hpEnemy;

    public float maxHpEnemy;

    public float dropExp;

    public EnemyStats(EnemyStatsSO enemyStatsSO)
    {
        this.nameEnemy = enemyStatsSO.nameEnemy;

        this.levelEnemy = enemyStatsSO.levelEnemy;

        this.hpEnemy = enemyStatsSO.hpEnemy;

        this.maxHpEnemy = enemyStatsSO.maxHpEnemy;

        this.dropExp = enemyStatsSO.dropExp;
    }
}


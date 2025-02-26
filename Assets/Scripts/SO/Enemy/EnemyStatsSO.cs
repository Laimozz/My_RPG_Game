
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyStats" , menuName ="Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    public string nameEnemy;

    public int levelEnemy;

    public float hpEnemy;

    public float maxHpEnemy;

    public float dropExp;
}

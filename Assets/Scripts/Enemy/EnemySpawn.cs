using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawn : MonoBehaviour
{
    [Header("Scene 1")]
    [SerializeField] private GameObject enemyPrefapSlimeElec;
    [SerializeField] private GameObject enemyPrefapSlimeFire;

    [Header("Scene 2")]
    [SerializeField] private GameObject enemyPrefapBatman;
    [SerializeField] private GameObject enemyPrefapBeholder;
    [SerializeField] private GameObject enemyPrefapSkeleton;

    [Header("Scene 3")]
    [SerializeField] private GameObject enemyHusky;
    [SerializeField] private GameObject enemyHellhound;
    [SerializeField] private GameObject enemyFirePhantom;
    [SerializeField] private GameObject enemyMalakar;

    [Header("Scene 4")]
    [SerializeField] private GameObject enemyYeti;
    [SerializeField] private GameObject enemyForstPhantom;

    [Header("Scene 5")]
    [SerializeField] private GameObject enemyDarkGolbin;
    [SerializeField] private GameObject enemyElemental;
    [SerializeField] private GameObject enemyNecromancer;

    [Header("Scene 6")]
    [SerializeField] private GameObject enemyZombie;
    [SerializeField] private GameObject enemySnake;
    [SerializeField] private GameObject enemyOrc;

    [Header("Scene Final")]
    [SerializeField] private GameObject enemyBoss;

    [SerializeField] private Transform enemyParent;
    [SerializeField] private float timeToSpawn;

    public static EnemySpawn Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void Spawner(Vector3 pos , string name)
    {
        StartCoroutine(SpawnNewEnemy(pos , name));
    }

    IEnumerator SpawnNewEnemy(Vector3 pos , string name)
    {
        yield return new WaitForSeconds(timeToSpawn);
        GameObject enemy = null;
        if(name == "Slime Electricity")
        {
            enemy = Instantiate(enemyPrefapSlimeElec, pos, Quaternion.identity);
        }
        else if(name == "Slime Fire")
        {
            enemy = Instantiate(enemyPrefapSlimeFire, pos, Quaternion.identity);
        }
        else if(name == "Boss")
        {
            enemy = Instantiate(enemyBoss, pos, Quaternion.identity);
        }
        else if (name == "Batman")
        {
            enemy = Instantiate(enemyPrefapBatman, pos, Quaternion.identity);
        }
        else if (name == "Beholder")
        {
            enemy = Instantiate(enemyPrefapBeholder, pos, Quaternion.identity);
        }
        else if (name == "Skeleton")
        {
            enemy = Instantiate(enemyPrefapSkeleton, pos, Quaternion.identity);
        }
        else if (name == "Husky")
        {
            enemy = Instantiate(enemyHusky, pos, Quaternion.identity);
        }
        else if (name == "Hellhound")
        {
            enemy = Instantiate(enemyHellhound, pos, Quaternion.identity);
        }
        else if (name == "Fire Phantom")
        {
            enemy = Instantiate(enemyFirePhantom, pos, Quaternion.identity);
        }
        else if (name == "Malakar")
        {
            enemy = Instantiate(enemyMalakar, pos, Quaternion.identity);
        }
        else if (name == "Yeti")
        {
            enemy = Instantiate(enemyYeti, pos, Quaternion.identity);
        }
        else if (name == "Frost Phantom")
        {
            enemy = Instantiate(enemyForstPhantom, pos, Quaternion.identity);
        }
        else if (name == "DarkGoblin")
        {
            enemy = Instantiate(enemyDarkGolbin, pos, Quaternion.identity);
        }
        else if (name == "Elemental")
        {
            enemy = Instantiate(enemyElemental, pos, Quaternion.identity);
        }
        else if (name == "Necromancer")
        {
            enemy = Instantiate(enemyNecromancer, pos, Quaternion.identity);
        }
        else if (name == "Zombie")
        {
            enemy = Instantiate(enemyZombie, pos, Quaternion.identity);
        }
        else if (name == "Snake")
        {
            enemy = Instantiate(enemySnake, pos, Quaternion.identity);
        }
        else if (name == "Orc")
        {
            enemy = Instantiate(enemyOrc, pos, Quaternion.identity);
        }
        if (enemy != null)
        {
            enemy.transform.SetParent(enemyParent);
        }
        
    }
}

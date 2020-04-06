using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; protected set; }

    public GameObject EnemyPrefab;

    List<GameObject> enemies = new List<GameObject>();

    public EnemyManager()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Awake()
    {
        var enemy = GameObject.Instantiate(EnemyPrefab);
        enemy.transform.position = enemy.transform.position + new Vector3(2, 0, 5);

        enemies.Add(enemy);

        var enemy2 = GameObject.Instantiate(EnemyPrefab);
        enemy2.transform.position = enemy2.transform.position + new Vector3(-2, 0, 4);

        enemies.Add(enemy2);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool EnemyExists()
    {
        return enemies.Count > 0;
    }

    public GameObject GetNearestEnemy(Transform t)
    {
        float shortestDist = Mathf.Infinity;
        GameObject closest = null;
        foreach (var enemy in enemies)
        {
            float dist = Vector3.Distance(t.position, enemy.transform.position);
            if (dist < shortestDist)
            {
                shortestDist = dist;
                closest = enemy;
            }
        }
        return closest;
    }
}

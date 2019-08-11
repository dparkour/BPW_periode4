using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnTime = 5f;
    public List<Transform> SpawnPositions;
    public List<GameObject> Enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        Instantiate(Enemies[Random.Range(0, Enemies.Count)], SpawnPositions[Random.Range(0,SpawnPositions.Count)].position, Quaternion.identity);
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(Spawn());

    }
}

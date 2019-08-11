using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public float ExplosionSpawnTime;
    public float PowerUpSpawnTime;

    public GameObject ExplosionBarrel;
    public GameObject PowerUpBarrel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnExplosionBarrels());
        StartCoroutine(SpawnPowerUpBarrels());

    }

    IEnumerator SpawnExplosionBarrels()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 10, Random.Range(-10f, 10f));
        yield return new WaitForSeconds(ExplosionSpawnTime);
        Instantiate(ExplosionBarrel, randomPosition, Quaternion.identity);
        StartCoroutine(SpawnExplosionBarrels());
    }

    IEnumerator SpawnPowerUpBarrels()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 10, Random.Range(-10f, 10f));
        yield return new WaitForSeconds(PowerUpSpawnTime);
        Instantiate(PowerUpBarrel, randomPosition, Quaternion.identity);
        StartCoroutine(SpawnPowerUpBarrels());
    }

}

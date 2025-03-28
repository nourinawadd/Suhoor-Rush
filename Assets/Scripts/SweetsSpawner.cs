
using UnityEngine;

public class SweetsSpawner : MonoBehaviour
{
    public GameObject[] Prefab;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

   

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        int Prefab_Index = Random.Range(0, Prefab.Length);
        Instantiate(Prefab[Prefab_Index], transform.position + new Vector3(randomX, randomY, 0), Quaternion.identity);
        
    }    
}

using System.Collections;
using UnityEngine;

public class SpawnFallingObjects : MonoBehaviour
{
    public GameObject fallingObject;
    public float spawnRadius = 20f;
    public float spawnHeight = 5f;
    [Range(0.01f, 5f)] public float spawnRate = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 position = new Vector3( Random.Range(-spawnRadius, spawnRadius),
                spawnHeight,
                Random.Range(-spawnRadius, spawnRadius));
            GameObject fall = Instantiate(fallingObject, position, Quaternion.identity);
            fall.transform.localScale = Vector3.one * Random.Range(0.25f, 2f);
            Destroy(fall, 30f); // destroy after 30 seconds
            yield return new WaitForSeconds(spawnRate);
        }
    }
}

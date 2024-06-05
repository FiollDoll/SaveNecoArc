using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : MonoBehaviour
{
    public float modif = 1.1f;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject[] spawnObjects = new GameObject[0];
    [SerializeField] private allScripts scripts;

    public void Start() => StartCoroutine(SpawnObj());

    private IEnumerator SpawnObj()
    {
        Vector3 direction = new Vector3(0, 0, -5);
        Vector3 directionSpawn = new Vector3(Random.Range(12.9f, 28.46f), spawner.transform.position.y, spawner.transform.position.z);
        var obj = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], directionSpawn, Quaternion.identity);
        obj.GetComponent<Transform>().localScale = new Vector3(Random.Range(obj.GetComponent<Transform>().localScale.x, obj.GetComponent<Transform>().localScale.x * modif), Random.Range(obj.GetComponent<Transform>().localScale.y, obj.GetComponent<Transform>().localScale.y * modif), Random.Range(obj.GetComponent<Transform>().localScale.z, obj.GetComponent<Transform>().localScale.z * modif));
        obj.GetComponent<Rigidbody>().velocity = direction * 2 * modif;
        yield return new WaitForSeconds(1.1f / modif);
        StartCoroutine(SpawnObj());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    public Jump jumper;
    public GameObject borular;
    public float height;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject(time));
    }

    public IEnumerator SpawnObject(float time)
    {
        while (!jumper.isDead) {
            Instantiate(borular, new Vector3(1.0f, height, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(time-1f, time+1f));
        }
        
    }
}

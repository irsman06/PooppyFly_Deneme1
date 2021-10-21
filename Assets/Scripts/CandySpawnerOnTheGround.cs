using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class CandySpawnerOnTheGround : MonoBehaviour
{
    public GameObject specialCandy;
    public GameObject darkBlueCandy;
    public GameObject lightBlueCandy;
    public Jump unicornWalking;
    public float height;
    public float time;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject(time));
    }

    public IEnumerator SpawnObject(float time)
    {
        while (!unicornWalking.isDead)
        {
            spawnRandom();
            yield return new WaitForSeconds(Random.Range(0.15f, time));
        }

    }

    private void spawnRandom()
    {
        int randInt = Random.Range(1, 16);
        GameObject go;
        if (randInt == 1)
        {
            go = Instantiate(specialCandy, new Vector3(1, height), Quaternion.identity);
        }
        else if (randInt < 8)
        {
            go = Instantiate(darkBlueCandy, new Vector3(1, Random.Range(0.1f, height), 0), Quaternion.identity);
        }
        else 
        {
            go = Instantiate(lightBlueCandy, new Vector3(1, Random.Range(0.1f, height), 0), Quaternion.identity);
        }
        Destruct des = go.GetComponent<Destruct>();
        des.index = (int)Math.Floor(randInt/2f);
    }
}

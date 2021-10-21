using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject redCandy;
    public GameObject pinkCandy;
    public GameObject specialCandy;
    public GameObject darkBlueCandy;
    public GameObject lightBlueCandy;
    public GameObject carrotCandy;

    public float height;
    public float time;
    private const int SOUND_COUNT = 8;
    private float sequenceTime = 0;
    public float gapTime = 0.2f;
    public float period = 10;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject(time));
    }

    public IEnumerator SpawnObject(float time)
    {
        while (!isDead)
        {
            if (sequenceTime > time* period) {
                new WaitForSeconds(gapTime);
                for (int i = 0; i < 5; i++)
                {
                    spawnSequential(i, Random.Range(0, 5));
                }
                new WaitForSeconds(gapTime);
                sequenceTime = 0;
            }
            else {
                spawnRandom();
            }

            sequenceTime += time;
            yield return new WaitForSeconds(time);
        }

    }

    private void spawnSequential(int index, int randomIncrement) {

        GameObject go = Instantiate(redCandy, new Vector3(1, index*0.18f, 0), Quaternion.identity);
        Destruct des = go.GetComponent<Destruct>();
        des.index = index + randomIncrement;
    }

    private void spawnRandom() {
        int randInt = Random.Range(1, 8);
        GameObject go;
        if (randInt == 1) {
            go = Instantiate(carrotCandy, new Vector3(1, Random.Range(-height + 0.15f, height), 0), Quaternion.identity);
        }
        else
        {
            go = Instantiate(pinkCandy, new Vector3(1, Random.Range(-height + 0.15f, height), 0), Quaternion.identity);
        }
        Destruct des = go.GetComponent<Destruct>();
        des.index = randInt;
    }
}

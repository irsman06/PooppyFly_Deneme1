using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    public int lifeTime = 7;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }
}

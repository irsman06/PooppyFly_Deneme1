using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public AudioClip clip8;
    public int index = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioClip playing = clip1;

        switch (index) {
            case 0:
                playing = clip1;
                break;
            case 1:
                playing = clip2;
                break;
            case 2:
                playing = clip3;
                break;
            case 3:
                playing = clip4;
                break;
            case 4:
                playing = clip5;
                break;
            case 5:
                playing = clip6;
                break;
            case 6:
                playing = clip7;
                break;
            case 7:
                playing = clip8;
                break;
            default:
                playing = clip8;
                break;
        }
        audioSource.PlayOneShot(playing);
        transform.position = Vector3.one * 9999f;
        Destroy(gameObject, playing.length);
    }
}

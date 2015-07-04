using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime; // this is the time of the gameObject

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
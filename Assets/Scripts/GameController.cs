using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;  // total of hazards per Wave
    public float spawnWait;  // time between Spawns
    public float startWait;  // initial time before start a wave
    public float waveWait;   //  time between waves

    void Start()
    {
        StartCoroutine ( SpawnWaves() );   //the way to call a Coroutine
    }

    IEnumerator SpawnWaves ()  // to WaitForSeconds we need this function to be iEnumerator
    {
        yield return new WaitForSeconds(startWait);  // initial time before start the wave
        while (true)    // endless loop
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, +spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;  //no rotation at Spawning
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); // start a coroutine that pause this olny this function
            }
            yield return new WaitForSeconds(waveWait);  // time between waves
        }
    }
}

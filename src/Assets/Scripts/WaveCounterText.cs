using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCounterText : MonoBehaviour
{
    public GameObject waveSpawnerObject;
    private WaveSpawner waveSpawner;
    // Start is called before the first frame update
    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = waveSpawner.currentWave.ToString();
    }
    void Start()
    {
        waveSpawner = waveSpawnerObject.GetComponent<WaveSpawner>();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;

    private float countdown = 2f;
    private int waveIndex = 0;

    public Text waveCountdownText;

	void Update () 
	{
	    if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());    // since ienumerator, we cant just call SpawnWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); // this is so the countdown never goes below 0

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

    IEnumerator SpawnWave() // ienumerator is available from System.Collection, allowed us to pause this piece of code for amount of seconds
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

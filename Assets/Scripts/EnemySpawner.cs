using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [Range(0.1f,120f)][SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParent;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip spawnedEnemySFX;

    int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        scoreText.text = enemyCount.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyCount += 1;
            scoreText.text = enemyCount.ToString();
            newEnemy.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }        
    }
}

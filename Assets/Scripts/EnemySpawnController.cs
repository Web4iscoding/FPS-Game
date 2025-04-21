using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemySpawnController : MonoBehaviour
{
    public int initialEnemiesPerWave = 3;
    public int currentEnemiesPerWave;

    public float spawnDelay = 0.5f;

    public  int currentWave = 0;
    public float waveCooldown = 10.0f;

    public bool inCooldown;
    public float cooldownCounter;

    public List<Enemy> currentEnemiesAlive;

    public GameObject enemyPrefab;
    
    public CurrentScene currentScene;
    public bool continueSpawn = true;
    public CheckScene checkScene;
    public TextMeshProUGUI waveIndicatorUI;

    private void Start()
    {
        if (SelectMode.Instance.mode == SelectMode.Mode.Tutorial)
            spawnDelay = 0; // spawn immediately in tutorial mode

        // number of enemies spawning according to enemy type, difficulty and mode

        if (enemyPrefab.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Mannequin)
        {
            if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
                initialEnemiesPerWave = 4;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
                initialEnemiesPerWave = 3;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
                initialEnemiesPerWave = 4;
            else
                initialEnemiesPerWave = 5;
        }

        else if (enemyPrefab.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Zombie)
        {
            if (SelectMode.Instance.mode == SelectMode.Mode.Tutorial)
                initialEnemiesPerWave = 1;
            else if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
                initialEnemiesPerWave = 10;
            else if (SelectMode.Instance.mode == SelectMode.Mode.Battle || Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
                initialEnemiesPerWave = 8;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
                initialEnemiesPerWave = 10;
            else
                initialEnemiesPerWave = 20;
        }
        
        currentEnemiesPerWave = initialEnemiesPerWave;

        StartNextWave();
    }

    private void Update()
    {
        // load boss scene after preboss scene is done
        if (checkScene.mannequinStopSpawn && checkScene.zombieStopSpawn && enemyPrefab.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Mannequin)
            SceneManager.LoadScene("MannequinBoss");

        // current wave UI updates in battle mode
        if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
            if (currentScene == CurrentScene.Scene1)
                waveIndicatorUI.text = $"Living Room: Wave {currentWave}";
            else if (currentScene == CurrentScene.Scene2)
                waveIndicatorUI.text = $"Domain: Wave {currentWave}";
            else if (currentScene == CurrentScene.Scene3)
                waveIndicatorUI.text = $"City: Wave {currentWave}";
            else if (currentScene == CurrentScene.BattlePreBoss && enemyPrefab.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Mannequin)
                waveIndicatorUI.text = $"PreBoss";
            else if (currentScene == CurrentScene.BattleBoss)
                waveIndicatorUI.text = $"Boss Battle";

        // checking dead enemies and start cool down between waves

        List<Enemy> enemiesToRemove = new List<Enemy>();
        foreach (Enemy enemy in currentEnemiesAlive)
        {
            if (enemy.isDead)
            {
                enemiesToRemove.Add(enemy);
            }
        }

        foreach (Enemy enemy in enemiesToRemove)
        {
            currentEnemiesAlive.Remove(enemy);
        }

        enemiesToRemove.Clear();

        if (currentEnemiesAlive.Count == 0 && inCooldown == false)
        {
            StartCoroutine(WaveCooldown());
        }

        if (inCooldown)
            cooldownCounter -= Time.deltaTime;
        else
            cooldownCounter = waveCooldown;

    }

    // CurrentScene enum
    public enum CurrentScene
    {
        Scene1, Scene2, Scene3, BattlePreBoss, BattleBoss
    }

    private void StartNextWave()
    {

        // handling enemy spawn in preboss scene
        if (currentWave == 2 && currentScene == CurrentScene.BattlePreBoss)
        {
            continueSpawn = false;
            if (enemyPrefab.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Mannequin)
                checkScene.mannequinStopSpawn = true;
            else if (enemyPrefab.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Zombie)
                checkScene.zombieStopSpawn = true;
        }

        // load next scene when waves are finished in battle mode        
        if (currentWave == 3)
        {
            if (SelectMode.Instance.mode == SelectMode.Mode.Battle && currentScene == CurrentScene.Scene1)
                SceneManager.LoadScene("Scene2");
            else if (SelectMode.Instance.mode == SelectMode.Mode.Battle && currentScene == CurrentScene.Scene2)
                SceneManager.LoadScene("Scene3");
            else if (SelectMode.Instance.mode == SelectMode.Mode.Battle && currentScene == CurrentScene.Scene3)
                SceneManager.LoadScene("BattlePreBoss");
        }

        // next wave

        currentEnemiesAlive.Clear();
        if (continueSpawn)
        {
            currentWave++;
            StartCoroutine(SpawnWave());
        }
    }

    // managing spawning of enemies
    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentEnemiesPerWave; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-6f, 6f), 0f, Random.Range(-6f, 6f));
            Vector3 spawnPosition = transform.position + spawnOffset;

            var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Enemy enemyScript = enemy.GetComponent<Enemy>();

            currentEnemiesAlive.Add(enemyScript);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // cooldown of wave then start next wave
    private IEnumerator WaveCooldown()
    {
        inCooldown = true;

        yield return new WaitForSeconds(waveCooldown);

        inCooldown = false;
        if (SelectMode.Instance.mode == SelectMode.Mode.Battle && enemyPrefab.GetComponent<Enemy>().enemyType != Enemy.EnemyType.PrisonRealm)
            currentEnemiesPerWave *= 2;
        StartNextWave();
    }
}

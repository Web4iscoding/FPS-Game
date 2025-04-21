using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    
    public int HP = 100, totalHP;
    private Animator animator;
    public Transform player;
    public float destructionTime;

    public TextMeshProUGUI EnemyHealthUI;
    public TextMeshProUGUI BossHealthUI;

    private NavMeshAgent navAgent;

    public bool isDead;

    public EnemyType enemyType;

    private void Update()
    {
        // managing HP bar UI of enemy based of enemy type and health status

        if ((double) HP / totalHP > 0.5)
            EnemyHealthUI.color = new Color(0, 255, 0);
        else if ((double) HP / totalHP <= 0.5 && (double) HP / totalHP > 0)
            EnemyHealthUI.color = new Color(255, 216, 0);
        else if (HP <= 0)
            EnemyHealthUI.color = new Color(255, 0, 0);

        if (enemyType == EnemyType.MannequinBoss)
        {   
            EnemyHealthUI.text = $"Health: {HP}";
            if (HP > 0)
                BossHealthUI.text = $"BOSS: {HP}";
            if ((double) HP / totalHP > 0.5) {
                BossHealthUI.color = new Color(0, 255, 0);
            }
            else if ((double) HP / totalHP <= 0.5 && (double) HP / totalHP > 0) {
                BossHealthUI.color = new Color(255, 216, 0);
            }
            else if (HP <= 0) { 
                BossHealthUI.color = new Color(255, 0, 0);
                BossHealthUI.text = "BOSS: DEAD";
            }
        }
        else 
        {
            if (SelectMode.Instance.mode == SelectMode.Mode.Tutorial)
                EnemyHealthUI.text = "Health: --";
            else
                EnemyHealthUI.text = $"Health: {HP}";
        }
    }
    private void Start()
    {   
        if (SelectMode.Instance.mode == SelectMode.Mode.Tutorial)
            destructionTime = 0; // self destroy immediately in tutorial

        // adjusting enemy HP based on enemy type, difficulty and mode

        if (enemyType == EnemyType.Mannequin)
        {
            if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
                HP = 200;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
                HP = 100;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
                HP = 200;
            else
                HP = 300;
        }
        else if (enemyType == EnemyType.PrisonRealm)
        {
            if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
                HP = 200;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
                HP = 50;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
                HP = 100;
            else
                HP = 200;
        }
        else if (enemyType == EnemyType.Zombie)
        {
            if (SelectMode.Instance.mode == SelectMode.Mode.Tutorial)
                HP = 2147483647;
            else if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
                HP = 150;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
                HP = 100;
            else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
                HP = 150;
            else
                HP = 200;
        }

        // initializing and assigning values
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        
        totalHP = HP;
    }

    // EnemyType enum
    public enum EnemyType {
        Mannequin, PrisonRealm, Zombie, MannequinBoss
    }

    // Take damage when hit by weapon
    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0;
            GetComponent<Collider>().enabled = false;
            if (enemyType == EnemyType.Zombie || enemyType == EnemyType.PrisonRealm)
                animator.SetTrigger("Die");
            else
                animator.SetBool("DieMannequin", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            if (enemyType == EnemyType.Zombie)
                animator.SetBool("isAttacking_alt", false);
            isDead = true;
            StartCoroutine(DestroySelf(destructionTime));  
        }
        else
        {
            int random = UnityEngine.Random.Range(1, 3);
            if (random == 1)
                animator.SetTrigger("Damaged");
            else
                animator.SetTrigger("Damaged_alt");
        }

        
    }

    // self destroy when death
    private IEnumerator DestroySelf(float destructionTime)
    {
        yield return new WaitForSeconds(destructionTime);

        Destroy(gameObject);
        Destroy(EnemyHealthUI.gameObject);
        if (enemyType == EnemyType.MannequinBoss)
            SceneManager.LoadScene("WinGame");
    }

}


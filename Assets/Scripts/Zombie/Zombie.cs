using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public ZombieHand zombieHand;

    public int zombieDamage;

    private void Start()
    {
        // adjusting zombie damage based on difficulty and mode
        if (SelectMode.Instance.mode == SelectMode.Mode.Tutorial)
            zombieDamage = 0;
        else if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
            zombieDamage = 4;
        else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
            zombieDamage = 2;
        else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
            zombieDamage = 4;
        else
            zombieDamage = 6;
        // assigning damage to damage of zombie hand
        zombieHand.damage = zombieDamage;
    }
}

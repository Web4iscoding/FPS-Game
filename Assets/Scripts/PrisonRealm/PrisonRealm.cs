using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonRealm : MonoBehaviour
{
    public int damage;

    private void Start()
    {
        // adjusting prison realm damage based on difficulty and mode
        if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
            damage = 6;
        else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
            damage = 2;
        else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
            damage = 4;
        else 
            damage = 6;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mannequin : MonoBehaviour
{
    public MannequinHand mannequinHand;

    public int mannequinDamage;

    public MannequinType mannequinType;

    private void Start()
    {
        // adjusting mannequin damage based on difficulty, mannequin type and mode
        if (mannequinType == MannequinType.MannequinBoss)
            mannequinDamage = 40;
        else if (SelectMode.Instance.mode == SelectMode.Mode.Battle)
            mannequinDamage = 10;
        else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
            mannequinDamage = 5;
        else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
            mannequinDamage = 10;
        else
            mannequinDamage = 15;
        // assigning damage to damage of mannequin hand
        mannequinHand.damage = mannequinDamage;
    }

    // Types for mannequin enemy
    public enum MannequinType {
        Mannequin, MannequinBoss
    }
}

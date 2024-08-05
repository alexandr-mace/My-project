using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public int RollDice()
    {
        int die1 = Random.Range(1, 7);
        int die2 = Random.Range(1, 7);
        int total = die1 + die2;
        Debug.Log($"Dice rolled: {die1} and {die2}, total: {total}");
        return total;
    }
}
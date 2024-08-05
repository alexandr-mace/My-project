using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public DiceRoller diceRoller;
    public Text resultText;

    public int playerHealth = 100;
    public int opponentHealth = 100;
    public Text playerHealthText;
    public Text opponentHealthText;

    public Card[] playerHand;
    public Card[] opponentHand;

    public Button[] playerCardButtons; // Кнопки выбора карт для игрока

    private bool playerTurn = true; // Флаг для отслеживания текущего хода

    void Start()
    {
        UpdateHealthUI();
        SetupCardButtons();
    }

    void UpdateHealthUI()
    {
        playerHealthText.text = $"Player Health: {playerHealth}";
        opponentHealthText.text = $"Opponent Health: {opponentHealth}";
    }

    void SetupCardButtons()
    {
        for (int i = 0; i < playerCardButtons.Length; i++)
        {
            int index = i; // Локальная переменная для использования в лямбда-выражении
            playerCardButtons[i].onClick.AddListener(() => playerHand[index].SelectCard());
        }
    }

    public void OnRollDiceButtonPressed()
    {
        if (playerTurn)
        {
            PlayerTurn();
        }
        else
        {
            OpponentTurn();
        }
    }

    void PlayerTurn()
    {
        int damage = diceRoller.RollDice();

        foreach (var card in playerHand)
        {
            if (card.IsSelected())
            {
                damage = Mathf.RoundToInt(damage * card.GetDamageModifier(damage));
            }
        }

        opponentHealth -= damage;
        resultText.text = $"Player deals {damage} damage!";
        UpdateHealthUI();

        playerTurn = false;
    }

    void OpponentTurn()
    {
        int damage = diceRoller.RollDice();

        foreach (var card in opponentHand)
        {
            if (card.IsSelected())
            {
                damage = Mathf.RoundToInt(damage * card.GetDamageModifier(damage));
            }
        }

        playerHealth -= damage;
        resultText.text = $"Opponent deals {damage} damage!";
        UpdateHealthUI();

        playerTurn = true;
    }
}

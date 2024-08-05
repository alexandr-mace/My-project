using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int faceValue; // Значение стороны кубика
    public bool isPlayerCard; // Карта принадлежит игроку
    private bool selected = false; // Флаг выбора карты
    public Text faceValueText; // UI элемент для отображения значения стороны кубика
    public Image cardImage; // UI элемент для отображения карты

    void Start()
    {
        UpdateCardUI();
    }

    public float GetDamageModifier(int rolledValue)
    {
        if (rolledValue == faceValue)
        {
            return isPlayerCard ? 1.5f : 0.5f;
        }
        return 1.0f;
    }

    public void SelectCard()
    {
        selected = !selected; // Переключение состояния выбора
        UpdateCardUI();
    }

    public bool IsSelected()
    {
        return selected;
    }

    private void UpdateCardUI()
    {
        faceValueText.text = $"Face: {faceValue}";

        if (selected)
        {
            cardImage.color = Color.yellow; // Изменение цвета карты при выборе
        }
        else
        {
            cardImage.color = Color.white; // Исходный цвет карты
        }
    }
}

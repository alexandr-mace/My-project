using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int faceValue; // �������� ������� ������
    public bool isPlayerCard; // ����� ����������� ������
    private bool selected = false; // ���� ������ �����
    public Text faceValueText; // UI ������� ��� ����������� �������� ������� ������
    public Image cardImage; // UI ������� ��� ����������� �����

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
        selected = !selected; // ������������ ��������� ������
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
            cardImage.color = Color.yellow; // ��������� ����� ����� ��� ������
        }
        else
        {
            cardImage.color = Color.white; // �������� ���� �����
        }
    }
}

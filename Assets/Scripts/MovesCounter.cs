using UnityEngine;
using TMPro;

public class MovesCounter : MonoBehaviour
{
    public int maxMoves = 5;
    public int currentMoves = 0;

    public TextMeshProUGUI movesText;

    private void Start()
    {
        UpdateMovesText();
    }

    public bool CanMove()
    {
        return currentMoves < maxMoves;
    }

    public void IncrementMoves()
    {
        currentMoves++;
        UpdateMovesText();
    }

    private void UpdateMovesText()
    {
        movesText.text = $"Moves Left: {maxMoves - currentMoves}";
    }
}

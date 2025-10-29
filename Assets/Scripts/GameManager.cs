using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winTextObject;
    public GameObject restartButton;

    private bool gameEnded = false;

    private void Start()
    {
        if (winTextObject == null || restartButton == null)
        {
            Debug.LogError("Asignar winTextObject y restartButton en el inspector.");
            return;
        }
        winTextObject.SetActive(false);
        restartButton.SetActive(false);
    }

    public void EndGame(bool won)
    {
        if (gameEnded) return;
        gameEnded = true;

        winTextObject.SetActive(true);
        winTextObject.GetComponent<TMPro.TextMeshProUGUI>().text = won ? "You Win!" : "You Lose!";

        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

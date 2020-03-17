using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Slider progressBar;
    public Text currentLevel;
    public Text nextLevel;
    private void OnEnable()
    {
        GameManager.ExpChanged += AdjustSlider;
        GameManager.LevelChanged += HandleEdges;
        currentLevel.text = GameManager.Instance.level.ToString();
        nextLevel.text = (GameManager.Instance.level + 1).ToString();
    }

    private void OnDisable()
    {
        GameManager.ExpChanged -= AdjustSlider;
        GameManager.LevelChanged -= HandleEdges;
    }

    private void AdjustSlider(int exp)
    {
        var normalizedValue = (float) exp / GameManager.Instance.expToLevel;
        progressBar.value = normalizedValue;
    }

    private void HandleEdges(int level)
    {
        currentLevel.text = level.ToString();
        nextLevel.text = (level + 1).ToString();
    }
}

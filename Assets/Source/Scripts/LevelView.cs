using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;

    public void UpdateLevel(int level)
    {
        _levelText.text = "Level: " + (level + 1);
    }
}



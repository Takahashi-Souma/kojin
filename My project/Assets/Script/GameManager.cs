using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int killCount = 0;
    public TextMeshProUGUI killText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateKillText();
    }

    public void AddKill()
    {
        killCount++;
        UpdateKillText();
    }

    void UpdateKillText()
    {
        killText.text = "Kills : " + killCount;
    }
}
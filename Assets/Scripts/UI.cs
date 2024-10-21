using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI playerLifeText;
    public TextMeshProUGUI baseLifeText;
    public TextMeshProUGUI waveText;

    public Life playerLife;
    public Life baseLife;

    public WavesManager wavesManager;
    void Update()
    {
        playerLifeText.SetText($"{playerLife.amount}");
        baseLifeText.SetText($"{baseLife.amount}");
        waveText.SetText($"Oleadas\nrestantes:\n {wavesManager.wavesRemaining}");
    }
}


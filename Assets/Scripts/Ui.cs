using TMPro;
using UnityEngine;

public class PanelPositioner : MonoBehaviour
{
    public TextMeshProUGUI textWave;
    public TextMeshProUGUI textBase;
    public TextMeshProUGUI textPlayer;
    public Life baseLife;
    public Life playerLife;
    public WavesManager wavesController;
    public NewSpawner spawner;

    void Update()
    {
        //Controlar la wave actual
        if (wavesController.waves == null)
        {
            spawner.StartSpawner();
            textWave.SetText("Oleada 2/3");
        }    
        
        //Actualizar el texto según la vida de la base actual
        textBase.SetText($"{baseLife.amount}");
        textPlayer.SetText($"{playerLife.amount}");


    }
}


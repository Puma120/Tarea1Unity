using UnityEngine;
using UnityEngine.SceneManagement;
public class WavesGameMode : MonoBehaviour
{
    public Life playerLife;
    public Life baseLife;

    void Update()
    {
        if(EnemysManager.instance.enemys.Count <= 0 && WavesManager.instance.wavesRemaining <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        if (playerLife.amount <= 0 || baseLife.amount <=0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}

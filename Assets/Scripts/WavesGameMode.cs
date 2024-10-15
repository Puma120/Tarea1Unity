using UnityEngine;
using UnityEngine.SceneManagement;
public class WavesGameMode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Life playerLife;
    public Life baseLife;

    // Update is called once per frame
    void Update()
    {
        if(EnemysManager.instance.enemys.Count <= 0 && WavesManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        if (playerLife.amount <= 0 || baseLife.amount <=0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}

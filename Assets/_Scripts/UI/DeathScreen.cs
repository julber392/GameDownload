using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    void Awake()
    {
        deathScreen.SetActive(false);
    }

    public void DeathScreenActivate()
    {
        deathScreen.SetActive(true);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

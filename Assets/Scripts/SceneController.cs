using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    // Source: https://www.youtube.com/watch?v=E25JWfeCFPA

    public static SceneController instance;
    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
        
    }

    public void StorePlayerHealth()
    {
        if(GameObject.Find("Player"))
        {
            Damageable player = GameObject.Find("Player").GetComponent<Damageable>();
            if (player != null)
            {
                GameData.PlayerHealth = player.Health;
            }
        }
    }
    public void NextScene()
    {
        StorePlayerHealth();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        StorePlayerHealth();
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

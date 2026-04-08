using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuSceneManger : MonoBehaviour
{
    int playIndex = 1;
    Vector3 playerPos;
    Vector3 oldplayerpos;
    public void goToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void quit()
    {
        Application.Quit();
    }
   
}

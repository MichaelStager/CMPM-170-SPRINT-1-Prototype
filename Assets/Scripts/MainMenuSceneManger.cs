using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuSceneManger : MonoBehaviour
{
    int playIndex = 1;
    public void goToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void quit()
    {
        Application.Quit();
    }

}

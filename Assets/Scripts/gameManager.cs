using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    TaskManager taskManager;
    AdManager adManager;
    [SerializeField] float levelTime = 360f;
    [SerializeField] AudioSource winSFX;
    float currentTime = 0;
    bool isWinner = false;
    public bool isGameOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        adManager = FindAnyObjectByType<AdManager>();
        taskManager = FindAnyObjectByType<TaskManager>();
        currentTime = levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            Debug.Log(currentTime);

            if (currentTime <= 0)
            {
                Debug.Log("you lose");
                isWinner = false;
                isGameOver = true;
                SceneManager.LoadScene(3); //reloads the scene to reset the game, this is a placeholder for a lose screen that will be implemented in the future.
            }

            if (taskManager.AreAllTaskFinshed())
            {

                Debug.Log("you win");
                isWinner = true;
                isGameOver = true;
                StartCoroutine("startWin");
            }
        }
    }

       public IEnumerator startWin()
        {
            winSFX.Play();
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(2);
        }
    }


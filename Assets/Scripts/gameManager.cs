using UnityEngine;

public class gameManager : MonoBehaviour
{
    TaskManager taskManager;
    [SerializeField] float levelTime = 360f;
    float currentTime = 0;
    bool isWinner = false;
    public bool isGameOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            }

            if (taskManager.AreAllTaskFinshed())
            {
                Debug.Log("you win");
                isWinner = true;
                isGameOver = true;
            }
        }

    }
}

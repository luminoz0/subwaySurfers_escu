using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
   [SerializeField]
   private UnityEvent onGameStart;
   [SerializeField]
   private UnityEvent onGameLose;
   private void Start ()
    {
        StartGame();
    }
    public void StartGame()
    {
        onGameStart?.Invoke();
    }
     public void LoseGame()
    {
        onGameLose?.Invoke();
    }
}

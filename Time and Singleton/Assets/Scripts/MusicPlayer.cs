using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField, Range(0f, 10f), Tooltip("Player X Position")] private float x;
    
    // This is boilerplate singleton pattern
    void Awake()
    {
        // make sure the object name in <> matches the class name above
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        if (numOfMusicPlayers > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}

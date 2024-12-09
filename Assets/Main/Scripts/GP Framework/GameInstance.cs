using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInstance : MonoBehaviour
{
    public static GameInstance instance;
    
    public bool debugMode;

    public int playerCount;
    public List<ChickenConfig> playerConfigs = new List<ChickenConfig>();
    
    public Dictionary<Gamepad, Coroutine> gamepadRumbleCoroutines = new Dictionary<Gamepad, Coroutine>();
    
    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    
    private async void Start() {
        if (!debugMode) {
            CSceneManager.LoadScene(SceneNames.MainMenu);
        }
    }
}

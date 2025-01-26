using Unity.Netcode;
using UnityEngine;

public class AssignRole : MonoBehaviour
{

    public void AssignClient() {
        GameManager.Instance.SetPlayerType(PlayerType.Client);
        NetworkManager.Singleton.StartClient();
        SceneManager.ChangeScene(Scenes.GameScene);
    }

    public void AssignHost() {
        GameManager.Instance.SetPlayerType(PlayerType.Host);
        NetworkManager.Singleton.StartHost();
        GameManager.Instance.ChangeGameState(GameState.Configuring);
        SceneManager.ChangeScene(Scenes.GameScene);
    }
}
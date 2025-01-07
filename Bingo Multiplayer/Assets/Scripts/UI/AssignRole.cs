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
        SceneManager.ChangeScene(Scenes.GameScene);
    }
}
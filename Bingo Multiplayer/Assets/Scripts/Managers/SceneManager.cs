public static class SceneManager
{
    public static void ChangeScene(Scenes gameScene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene.ToString());
    }
}

public enum Scenes {
    MainMenuScene = 0,
    GameScene = 1
}

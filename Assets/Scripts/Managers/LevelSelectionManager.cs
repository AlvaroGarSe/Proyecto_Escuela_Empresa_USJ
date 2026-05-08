// *************************************************************** //
// Script done by Alvaro & Jorge Kojtych
// Loads and unloads the minigames scenes
// In progress
// The unload is left
// *************************************************************** //
using System.IO;
// using UnityEditor.SearchService;
using UnityEngine;
using System.Collections.Generic;

public class LevelSelectionManager : PersistentLazySingleton<LevelSelectionManager>
{
    private enum SceneType { MainMenu, ScoreScene, Minigame }

    [SerializeField] private SceneField m_MainMenuSceneName;
    [SerializeField] private SceneField m_ScoreSceneName;
    [SerializeField] private List<SceneField> m_MinigameScenes;
    private Queue<SceneField> m_MinigameScenesQueue = new Queue<SceneField>();
    private SceneType m_CurrentSceneType = SceneType.MainMenu;

    private void Start()
    {
        FillQueue();
    }

    private void FillQueue()
    {
        m_MinigameScenesQueue.Clear();

        // Shuffle
        List<SceneField> shuffledScenes = new List<SceneField>(m_MinigameScenes);
        for (int i = 0; i < shuffledScenes.Count; i++)
        {
            SceneField temp = shuffledScenes[i];
            int randomIndex = Random.Range(i, shuffledScenes.Count);
            shuffledScenes[i] = shuffledScenes[randomIndex];
            shuffledScenes[randomIndex] = temp;
        }

        foreach (var scene in shuffledScenes)
        {
            m_MinigameScenesQueue.Enqueue(scene);
        }
    }

    public void GoToNextScene()
    {
        switch (m_CurrentSceneType)
        {
            case SceneType.MainMenu:
                ChooseRandomMinigame();
                m_CurrentSceneType = SceneType.Minigame;
                break;
            case SceneType.Minigame:
                GoToScoreScene();
                m_CurrentSceneType = SceneType.ScoreScene;
                break;
            case SceneType.ScoreScene:
                GoToMainMenu();
                m_CurrentSceneType = SceneType.MainMenu;
                break;
        }
    }

    private void ChooseRandomMinigame()
    {
        SceneField nextMinigame = m_MinigameScenesQueue.Dequeue();
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextMinigame);
    }

    private void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(m_MainMenuSceneName);
        FillQueue();
    }

    private void GoToScoreScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(m_ScoreSceneName);
    }
}

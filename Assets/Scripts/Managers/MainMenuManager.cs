using UnityEngine;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private List<Sprite> playerSprites = new List<Sprite>();
    [SerializeField] private int selectedSpriteIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Gets the currently selected player sprite
    /// </summary>
    public Sprite GetCurrentPlayerSprite()
    {
        if (playerSprites.Count > 0 && selectedSpriteIndex >= 0 && selectedSpriteIndex < playerSprites.Count)
        {
            return playerSprites[selectedSpriteIndex];
        }
        return null;
    }

    /// <summary>
    /// Sets the selected sprite by index
    /// </summary>
    public void SetSelectedSprite(int index)
    {
        if (index >= 0 && index < playerSprites.Count)
        {
            selectedSpriteIndex = index;
        }
    }

    /// <summary>
    /// Gets all available player sprites
    /// </summary>
    public List<Sprite> GetAllPlayerSprites()
    {
        return playerSprites;
    }

    /// <summary>
    /// Gets the index of the currently selected sprite
    /// </summary>
    public int GetSelectedSpriteIndex()
    {
        return selectedSpriteIndex;
    }

    public void StartGame()
    {
        
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}

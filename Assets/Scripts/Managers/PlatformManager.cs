using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //******************************************************************************************************************************
    // Script done by Jorge Cristobal
    // Script state [IN PROGRESS]

    // This script purpouse is for managing the platforms behaviour at the Mountain Minigame.
    // Things to do:
    // - Create a pool for the platforms 
    // - Function that increases game speed after x seconds
    //*******************************************************************************************************************************
    // Prefabs plataformas   -- ¿Se podrian crear por codigo mejor?¿
    [SerializeField] private GameObject plataforma1;
    [SerializeField] private GameObject plataforma2;
    [SerializeField] private GameObject plataforma3;
    [SerializeField] private GameObject plataforma4;
    

    [SerializeField] private int numOfPlatforms = 10;
    [SerializeField] private float gameSpeedMultiplier = 1.0f;

    List<GameObject> platformPool = new List<GameObject>();

    private void Awake()
    {
        if (plataforma1 == null || plataforma2 == null || plataforma3 == null || plataforma4 == null) Debug.LogWarning("Platform Prefab not assigned");
        // Inicializa todas las plat|| aformas
        for (int i = 0; i < numOfPlatforms; i++) 
        {
            platformPool.Add(Instantiate(plataforma1));
            platformPool.Add(Instantiate(plataforma2));
            platformPool.Add(Instantiate(plataforma3));
            platformPool.Add(Instantiate(plataforma4));
        }
        
    }
    public GameObject GetPlatformFromPool()
    {
        GameObject platform = platformPool[0];
        if (platform == null)
        {
            platform = Instantiate(plataforma1);
            Debug.LogWarning("Not enough plataforms; instanciating a new one");

        }
        platformPool.Remove(platformPool[0]);
        return platform;
    }
    public void ReturnPlatformToPool(GameObject platform)
    {
        platformPool.Add(platform);
        platform.SetActive(false);
    }
    public float GetGameIncrementer()
    {
        return gameSpeedMultiplier;
    }
    
}

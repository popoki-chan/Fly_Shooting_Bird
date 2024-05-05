using System;
using GameTool;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float cooldown = 5f;
    private float spawnDelay;

    private void Update()
    {
        if (spawnDelay <= 0)
        {
            spawnDelay = cooldown;
            PoolingManager.Instance.GetObject(NamePrefabPool.Wall, null, transform.position).Disable(10f);
        }
        else
        {
            spawnDelay -= Time.deltaTime;
            
        }
    }
}

using System;
using GameTool;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wall : BasePooling
{
    private float speed = 5f;
    private int min = 1;
    private int max = 4;
    private int blockNumber = 4;
    private float bound;
    
    private void Update()
    {
        var position = transform.position;
        position = new Vector3(position.x - speed * Time.deltaTime, position.y, position.z);
        transform.position = position;
        
    }

    private void Awake()
    {
        bound = Camera.main.orthographicSize;
    }

    private void OnEnable()
    {
        bound = Camera.main.orthographicSize;
        CreateBlock();
    }

    private void CreateBlock()
    {
        float[] height = new float [blockNumber];
        height[0] = Random.Range(min, max);
        height[1] = bound - height[0];
        height[2] = Random.Range(min, max);
        height[3] = bound - height[2];

        float[] posy = new float[blockNumber];
        posy[0] = bound - height[0] / 2;
        posy[1] = height[1] / 2;
        posy[2] = -height[2] / 2;
        posy[3] = -bound + height[3] / 2;

        for (int i = 0; i < blockNumber; i++)
        {
            var block = (Block)PoolingManager.Instance.GetObject(NamePrefabPool.Block, transform,
                new Vector2(transform.position.x, posy[i]));
            block.BlockSpr.size = new Vector2(block.BlockSpr.size.x, height[i]);
        }
    }
}

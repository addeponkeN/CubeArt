using System.Collections.Generic;
using Util;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public static float MaterialSwapInterval = 0.75f;
    
    const int FieldWidth = 16;
    const int FieldHeight = 9;
    const float FieldSpacing = 2f;

    public GameObject Prefab_Cube;
    public Timer CubeSpawnTimer = 0.1f;

    List<CubeBytePoint> _cubePositionPool;
    
    void Start()
    {
        _cubePositionPool = new List<CubeBytePoint>();

        const int tot = FieldWidth * FieldHeight;
        for(int i = 0; i < tot; i++)
        {
            int x = i % FieldWidth;
            int y = i / FieldWidth;
            _cubePositionPool.Add(new CubeBytePoint(x, y));
        }
    }

    void Update()
    {
        if(CubeSpawnTimer.UpdateTick(Time.deltaTime) && _cubePositionPool.Count > 0)
        {
            SpawnCube();
        }
    }

    CubeBytePoint PopRandomCubeSpawnPoint()
    {
        return _cubePositionPool.PopRandom();
    }

    void SpawnCube()
    {
        var cubePoint = PopRandomCubeSpawnPoint();
        var cube = Instantiate(Prefab_Cube, transform);
        cube.transform.localPosition = cubePoint.ToVector3(FieldSpacing);
        var scr = cube.GetComponent<CubeArt>();
        scr.CubePoint = cubePoint;
        scr.KilledEvent += OnKilledEvent;
    }

    void OnKilledEvent(CubeArt cube)
    {
        _cubePositionPool.Add(cube.CubePoint);
    }
}
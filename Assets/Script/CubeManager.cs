using System.Collections.Generic;
using Util;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private const int FieldWidth = 16;
    private const int FieldHeight = 9;
    private const float FieldSpacing = 2f;
    
    public static float MaterialSwapInterval = 0.75f;

    public GameObject Prefab_Cube;
    public Timer CubeSpawnTimer = 0.1f;

    private List<CubeBytePoint> _cubePositionPool;

    private void Start()
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

    private void Update()
    {
        if(CubeSpawnTimer.UpdateTick(Time.deltaTime) && _cubePositionPool.Count > 0)
        {
            SpawnCube();
        }
    }

    private CubeBytePoint PopRandomCubeSpawnPoint()
    {
        return _cubePositionPool.PopRandom();
    }

    private void SpawnCube()
    {
        var cubePoint = PopRandomCubeSpawnPoint();
        var cube = Instantiate(Prefab_Cube, transform);
        cube.transform.localPosition = cubePoint.ToVector3(FieldSpacing);
        var scr = cube.GetComponent<CubeArt>();
        scr.CubePoint = cubePoint;
        scr.KilledEvent += OnKilledEvent;
    }

    private void OnKilledEvent(CubeArt cube)
    {
        _cubePositionPool.Add(cube.CubePoint);
    }
}
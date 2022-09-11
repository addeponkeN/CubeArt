using System;
using Script;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Get { get; private set; }

    [SerializeField]
    public MaterialCollection MaterialCollection;

    [NonSerialized]
    public CubeManager CubeManager;

    public GameObject Plane;

    void Awake()
    {
        Get = this;
    }

    void Start()
    {
        CubeManager = GameObject.Find("Cubes").GetComponent<CubeManager>();
    }

}

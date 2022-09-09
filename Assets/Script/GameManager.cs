using Script;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Get { get; private set; }

    [SerializeField]
    public MaterialCollection MaterialCollection;

    void Awake()
    {
        Get = this;
    }
}

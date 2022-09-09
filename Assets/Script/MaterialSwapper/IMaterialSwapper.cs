using UnityEngine;

namespace Script.MaterialSwapper
{
    public interface IMaterialSwapper
    {
        Renderer Renderer { get; set; }
        MaterialCollection MaterialCollection { get; set; }
        void Update();
        void Kill();
    }
}
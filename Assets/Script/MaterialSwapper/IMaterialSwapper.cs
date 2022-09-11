using UnityEngine;

namespace MaterialSwapper
{
    public interface IMaterialSwapper
    {
        Renderer Renderer { get; set; }
        MaterialCollection MaterialCollection { get; set; }
        void Update();
        void SetMaterial();
        void Kill();
    }
}
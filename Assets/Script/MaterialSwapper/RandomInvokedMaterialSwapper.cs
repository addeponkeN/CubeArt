using UnityEngine;

namespace Script.MaterialSwapper
{
    public class RandomInvokedMaterialSwapper : MonoBehaviour, IMaterialSwapper
    {
        public Renderer Renderer { get; set; }
        public MaterialCollection MaterialCollection { get; set; }

        void Start()
        {
            InvokeRepeating("SetMaterial", 0f, CubeManager.MaterialSwapInterval);
        }
        
        public void Update() { }
        public void SetMaterial()
        {
            Renderer.material = MaterialCollection.GetRandomMaterial();
        }

        public void Kill()
        {
            Destroy(this);
        }
    }
}
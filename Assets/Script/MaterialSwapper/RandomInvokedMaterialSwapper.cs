using UnityEngine;

namespace Script.MaterialSwapper
{
    public class RandomInvokedMaterialSwapper : MonoBehaviour, IMaterialSwapper
    {
        public Renderer Renderer { get; set; }
        public MaterialCollection MaterialCollection { get; set; }

        void Start()
        {
            InvokeRepeating("SetRandomMaterial", 0.5f, 1f);
        }
        
        public void Update() { }
        
        public void Kill()
        {
            Destroy(this);
        }

        public void SetRandomMaterial()
        {
            Renderer.material = GetRandomMaterial();
        }

        Material GetRandomMaterial()
        {
            var matNames = MaterialCollection.GetMaterialNames();
            var matName = matNames[Random.Range(0, matNames.Count - 1)];
            return MaterialCollection.GetMaterial(matName);
        }
        
    }
}
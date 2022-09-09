using Script.Util;
using UnityEngine;

namespace Script.MaterialSwapper
{
    public class RandomMaterialSwapper : IMaterialSwapper
    {
        public Renderer Renderer { get; set; }
        public MaterialCollection MaterialCollection { get; set; }

        public Timer SwapInterval = 0.5f;

        public RandomMaterialSwapper(MaterialCollection materialCollection, Renderer ren)
        {
            MaterialCollection = materialCollection;
            Renderer = ren;
        }

        public void Update()
        {
            if(SwapInterval.UpdateTick(Time.deltaTime))
            {
                SetRandomMaterial();
            }
        }

        public void Kill() { }

        public void SetRandomMaterial()
        {
            Renderer.material = GetRandomMaterial();
        }

        Material GetRandomMaterial()
        {
            var matNames = MaterialCollection.GetMaterialNames();
            var name = matNames[Random.Range(0, matNames.Count - 1)];
            return MaterialCollection.GetMaterial(name);
        }
        
    }
}
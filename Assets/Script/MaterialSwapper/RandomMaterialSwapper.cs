using Util;
using UnityEngine;

namespace MaterialSwapper
{
    public class RandomMaterialSwapper : IMaterialSwapper
    {
        public Renderer Renderer { get; set; }
        public MaterialCollection MaterialCollection { get; set; }

        public Timer SwapInterval = CubeManager.MaterialSwapInterval;

        public RandomMaterialSwapper(MaterialCollection materialCollection, Renderer ren)
        {
            MaterialCollection = materialCollection;
            Renderer = ren;
        }

        public void Update()
        {
            if(SwapInterval.UpdateTick(Time.deltaTime))
            {
                SetMaterial();
            }
        }

        public void SetMaterial()
        {
            Renderer.material = MaterialCollection.GetRandomMaterial();
        }

        public void Kill() { }
        
    }
}
using System.Collections;
using UnityEngine;

namespace MaterialSwapper
{
    public class RandomMaterialCoroutineSwapper : MonoBehaviour, IMaterialSwapper
    {
        public Renderer Renderer { get; set; }
        public MaterialCollection MaterialCollection { get; set; }

        bool _alive;

        void Start()
        {
            _alive = true;
            StartCoroutine(SetRandomMaterial());
        }

        public void SetMaterial()
        {
            Renderer.material = MaterialCollection.GetRandomMaterial();
        }

        IEnumerator SetRandomMaterial()
        {
            while(_alive)
            {
                yield return new WaitForSeconds(CubeManager.MaterialSwapInterval);
                SetMaterial();
            }
        }

        public void Update() { }

        public void Kill()
        {
            _alive = false;
        }
    }
}
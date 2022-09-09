using System.Collections;
using UnityEngine;

namespace Script.MaterialSwapper
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

        IEnumerator SetRandomMaterial()
        {
            while(_alive)
            {
                yield return new WaitForSeconds(1);
                Renderer.material = GetRandomMaterial();
            }
        }

        Material GetRandomMaterial()
        {
            var matNames = MaterialCollection.GetMaterialNames();
            var matName = matNames[Random.Range(0, matNames.Count - 1)];
            return MaterialCollection.GetMaterial(matName);
        }

        public void Update() { }

        public void Kill()
        {
            _alive = false;
        }
    }
}
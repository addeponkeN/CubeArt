using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class MaterialCollection
{
    public List<Material> Materials;

    public void AddMaterial(Material mat)
    {
        Materials.Add(mat);
    }

    public Material GetRandomMaterial()
    {
        var material = Materials[Random.Range(0, Materials.Count)];
        return GetMaterial(material.name);
    }

    public Material GetMaterial(string name)
    {
        for(int i = 0; i < Materials.Count; i++)
        {
            var mat = Materials[i];
            if(mat.name == name)
                return mat;
        }

        throw new Exception($"Material not found: {name}");
    }
    
}
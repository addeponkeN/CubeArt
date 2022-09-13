using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class MaterialScalableCollection
{
    public List<Material> Materials;

    //  used for blazing fast lookup when you have thousands of materials
    private Dictionary<string, Material> _materialDict;
    private bool _inited;

    public void Init()
    {
        _materialDict = new Dictionary<string, Material>();

        for(int i = 0; i < Materials.Count; i++)
        {
            var mat = Materials[i];
            _materialDict.Add(mat.name, mat);
        }

        _inited = true;
    }

    public void AddMaterial(Material mat)
    {
        if(!_inited)
            Init();

        Materials.Add(mat);
        _materialDict.Add(mat.name, mat);
    }

    public Material GetRandomMaterial()
    {
        if(!_inited)
            Init();

        var material = Materials[Random.Range(0, Materials.Count)];
        return GetMaterial(material.name);
    }

    public Material GetMaterial(string name)
    {
        if(!_inited)
            Init();

        if(_materialDict.TryGetValue(name, out var mat))
        {
            return mat;
        }

        throw new Exception($"Material not found: {name}");
    }
}
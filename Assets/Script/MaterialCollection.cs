using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class MaterialCollection
{
    public List<Material> Materials;

    List<string> _materialNames;
    Dictionary<string, Material> _materialDict;
    bool _inited;

    public void Init()
    {
        _materialDict = new Dictionary<string, Material>();
        _materialNames = new List<string>();

        for(int i = 0; i < Materials.Count; i++)
        {
            var mat = Materials[i];
            _materialDict.Add(mat.name, mat);
            _materialNames.Add(mat.name);
        }

        _inited = true;
    }

    public List<string> GetMaterialNames()
    {
        if(!_inited)
            Init();

        return _materialNames;
    }

    public void AddMaterial(Material mat)
    {
        if(!_inited)
            Init();

        Materials.Add(mat);
        _materialDict.Add(mat.name, mat);
        _materialNames.Add(mat.name);
    }

    public Material GetRandomMaterial()
    {
        if(!_inited)
            Init();

        var name = _materialNames[Random.Range(0, _materialNames.Count)];
        return GetMaterial(name);
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
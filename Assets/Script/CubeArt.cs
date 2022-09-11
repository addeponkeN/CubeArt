using System;
using Script.MaterialSwapper;
using Script.Util;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeArt : MonoBehaviour
{
    Renderer _ren;
    IMaterialSwapper _matSwapper;
    Vector3 _timeOffset;

    public CubeBytePoint CubePoint;
    public event Action<CubeArt> KilledEvent;

    void Start()
    {
        _ren = GetComponent<Renderer>();
        BadSelectRandomMaterialSwapper();
        _matSwapper.SetMaterial();

        var pi2 = Mathf.PI * 2f;
        _timeOffset = new Vector3(Random.Range(0, pi2), Random.Range(0, pi2), Random.Range(0, pi2));
    }

    void SetMaterialSwapper(IMaterialSwapper swap)
    {
        _matSwapper?.Kill();
        _matSwapper = swap;
    }

    void BadSelectRandomMaterialSwapper()
    {
        int i = Random.Range(0, 2);
        switch(i)
        {
            case 0:
                SetMaterialSwapper(new RandomMaterialSwapper(GameManager.Get.MaterialCollection, _ren));
                break;
            case 1:
                var matSwapperInvoked = gameObject.AddComponent<RandomMaterialInvokedSwapper>();
                matSwapperInvoked.Renderer = _ren;
                matSwapperInvoked.MaterialCollection = GameManager.Get.MaterialCollection;
                SetMaterialSwapper(matSwapperInvoked);
                break;
            case 2:
                var matSwapperCoroutine = gameObject.AddComponent<RandomMaterialCoroutineSwapper>();
                matSwapperCoroutine.Renderer = _ren;
                matSwapperCoroutine.MaterialCollection = GameManager.Get.MaterialCollection;
                SetMaterialSwapper(matSwapperCoroutine);
                break;
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        _matSwapper.Update();
        UpdateJuice();
    }

    void UpdateJuice()
    {
        var tf = transform;

        //  rotation juice
        const float rotationVal = 360f;
        var rot = tf.localEulerAngles;
        rot.x = Mathf.Sin(Time.time * 0.25f + _timeOffset.x) * rotationVal;
        rot.y = Mathf.Cos(Time.time * 0.25f + _timeOffset.y) * rotationVal;
        rot.z = Mathf.Sin(Time.time * 0.25f + _timeOffset.z + Mathf.PI * .5f) * rotationVal;
        tf.eulerAngles = rot;

        //  scale juice
        Vector3 baseScale = Vector3.one;
        const float offsetScale = 0.15f;
        var scale = tf.localScale;
        var t = Mathf.Sin(Time.time * 4f + _timeOffset.x) * offsetScale;
        scale.x = baseScale.x + t;
        scale.y = baseScale.y + t;
        scale.z = baseScale.z + t;
        tf.localScale = scale;
    }

    void OnDestroy()
    {
        KilledEvent?.Invoke(this);
    }
}
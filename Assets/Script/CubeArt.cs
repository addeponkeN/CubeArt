using Script.MaterialSwapper;
using Script.Util;
using UnityEngine;

public class CubeArt : MonoBehaviour
{
    Renderer _ren;
    IMaterialSwapper _matSwapper;
    IndexLooper _index;

    void Start()
    {
        _index = new IndexLooper(3);
        _ren = GetComponent<Renderer>();
        BadMaterialSelector();
    }

    void SetMaterialSwapper(IMaterialSwapper swap)
    {
        if(_matSwapper != null)
        {
            _matSwapper.Kill();
        }
        _matSwapper = swap;
    }

    void BadMaterialSelector()
    {
        int i = _index.Next();
        switch(i)
        {
            case 0:
                SetMaterialSwapper(new RandomMaterialSwapper(GameManager.Get.MaterialCollection, _ren));
                Debug.Log("OMEGA SWAPPER");
                break;
            case 1:
                var matSwapperInvoked = gameObject.AddComponent<RandomInvokedMaterialSwapper>();
                matSwapperInvoked.Renderer = _ren;
                matSwapperInvoked.MaterialCollection = GameManager.Get.MaterialCollection;
                SetMaterialSwapper(matSwapperInvoked);
                Debug.Log("INVOKED SWAPPER");
                break;
            case 2:
                var matSwapperCoroutine = gameObject.AddComponent<RandomMaterialCoroutineSwapper>();
                matSwapperCoroutine.Renderer = _ren;
                matSwapperCoroutine.MaterialCollection = GameManager.Get.MaterialCollection;
                SetMaterialSwapper(matSwapperCoroutine);
                Debug.Log("COROUTINE SWAPPER");
                break;
        }
    }

    void Update()
    {
        _matSwapper.Update();

        if(Input.GetKeyDown(KeyCode.F))
        {
            BadMaterialSelector();
        }
        
    }
}
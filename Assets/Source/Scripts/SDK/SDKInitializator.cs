using System;
using System.Collections;
using Agava.YandexGames;
using Agava.VKGames;
using UnityEngine;

public class SDKInitializator : MonoBehaviour
{
    private IEnumerator Start()
    {
#if UNITY_EDITOR
        yield break;
#endif

#if YANDEX_GAMES
        yield return YandexGamesSdk.Initialize(OnYandexSDKInitialize);
#endif

#if VK_GAMES
        yield return Agava.VKGames.VKGamesSdk.Initialize(OnVKSDKInitialize);
#endif
    }
}

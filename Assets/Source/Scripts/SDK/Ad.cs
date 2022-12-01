using UnityEngine;
using Agava.YandexGames;
using Agava.VKGames;
using System;

public class Ad : MonoBehaviour
{
    private bool _isAdShow;

    public void InterestialAdShow()
    {
#if UNITY_EDITOR
        return;
#endif

#if YANDEX_GAMES
        if (YandexGamesSdk.IsInitialized == false)
            return;

        if (_isAdShow == false)
            InterstitialAd.Show();
#endif

#if VK_GAMES
        Interstitial.Show();
#endif
    }

    public void ShowRewardVideo(Action onRewardedCallback = null)
    {


#if !UNITY_WEBGL || UNITY_EDITOR
        onRewardedCallback?.Invoke();
        return;
#endif

#if YANDEX_GAMES
        if (YandexGamesSdk.IsInitialized == false)
            return;

        if (_isAdShow == false)
            Agava.YandexGames.VideoAd.Show(OnVideoOpen, onRewardedCallback, OnVideoClose, OnError);
#endif

#if VK_GAMES
        Agava.VKGames.VideoAd.Show(onRewardedCallback, onVideoCloseCallback);
#endif
    }

    private void OnVideoOpen()
    {
        _isAdShow = true;
        AudioListener.pause = true;
    }

    private void OnVideoClose()
    {
        _isAdShow = false;

        if (Convert.ToBoolean(SettingsSaver.AudioPause))
        {
            AudioListener.pause = false;
            AudioListener.volume = 0.5f;

        }
    }

    private void OnError(string _)
    {
        _isAdShow = false;

        if (Convert.ToBoolean(SettingsSaver.AudioPause))
        {
            AudioListener.pause = false;
            AudioListener.volume = 0.5f;

        }
    }
}

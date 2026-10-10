using System;
using System.IO;
using BepInEx;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using TMPro;

namespace DandelionVoidKorean
{
    [BepInPlugin("noja.dandelionvoid.koreanfont", "Dandelion Void Korean Font", "1.0.0")]
    public class KoreanFontPlugin : BaseUnityPlugin
    {
        const string FontFileName = "NotoSansKR-Medium.ttf";
        TMP_FontAsset koreanFont;
        bool registered;
        float retryTimer;

        void Awake()
        {
            DontDestroyOnLoad(this);
            TryRegister();
        }

        void Update()
        {
            if (registered) return;
            retryTimer += Time.unscaledDeltaTime;
            if (retryTimer < 0.5f) return;
            retryTimer = 0f;
            TryRegister();
        }

        void TryRegister()
        {
            try
            {
                string dir = Path.GetDirectoryName(Info.Location);
                string path = Path.Combine(dir, FontFileName);
                if (!File.Exists(path))
                {
                    Logger.LogError("Font file not found: " + path);
                    registered = true; // give up
                    return;
                }

                if (koreanFont == null)
                {
                    koreanFont = TMP_FontAsset.CreateFontAsset(
                        path, 0, 90, 9, GlyphRenderMode.SDFAA, 2048, 2048);
                    if (koreanFont == null)
                    {
                        Logger.LogError("CreateFontAsset returned null for " + path);
                        registered = true;
                        return;
                    }
                    koreanFont.name = "NotoSansKR-Medium (Korean patch)";
                    DontDestroyOnLoad(koreanFont);
                    if (koreanFont.atlasTexture != null) DontDestroyOnLoad(koreanFont.atlasTexture);
                    if (koreanFont.material != null) DontDestroyOnLoad(koreanFont.material);
                }

                var fallbacks = TMP_Settings.fallbackFontAssets;
                if (fallbacks == null)
                {
                    // TMP settings not loaded yet; retry on a later frame
                    return;
                }
                if (!fallbacks.Contains(koreanFont)) fallbacks.Add(koreanFont);
                registered = true;
                Logger.LogInfo("Korean fallback font registered (" + fallbacks.Count + " global fallbacks)");

                foreach (var text in Resources.FindObjectsOfTypeAll<TMP_Text>())
                {
                    if (text != null) text.SetAllDirty();
                }
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to register Korean font: " + e);
                registered = true;
            }
        }
    }
}

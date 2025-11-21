using UnityEditor.Localization.Editor;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
namespace ExtractionRPG
{
public class LocalizationTextController : MonoBehaviour
    {
        public static LocalizationTextController Instance;
        private void Awake()
        {
            Instance = this;    
        }
        public void OnChangeLanguage(int _index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_index];
        }
    }
}

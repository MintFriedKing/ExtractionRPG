using UnityEngine;
using UnityEngine.UI;

namespace ExtractionRPG
{
public class LobbyUIController : MonoBehaviour
{ 
#region Canvas
 [SerializeField,Header("[HUDCanvas]")]private Canvas hudCanvas;
 [SerializeField,Header("[SettingAndExitCanvas]")]private Canvas settingAndExitCanvas; 
 #endregion 
#region SettingAndExit Canvas UI
 [SerializeField,Header("[SettingBackGround]")]private GameObject settingAndExitBackGround;
 [SerializeField,Header("[SettingObject]")]private GameObject settingPopUp;
 [SerializeField,Header("[ExitObject]")]private GameObject exitPopUp;
 [SerializeField,Header("[SoundContent]")]private GameObject soundContent;
 [SerializeField,Header("[videoContent]")]private GameObject videoContent;
 [SerializeField,Header("[LanguageContent]")]private GameObject languageContent;
 [SerializeField,Header("[Navigation SoundButton]")]private Button navigationSoundButton;
 [SerializeField,Header("[Navigation videoButton]")]private Button navigationVideoButton;
 [SerializeField,Header("[Navigation languageButton]")]private Button navigationLanguageButton; 
 [SerializeField,Header("[SettingExitButton]")]private Button settingExitButton;
 [SerializeField,Header("[MuteToggles - Yes]")] private Toggle muteYesToggle;
 [SerializeField,Header("[BGMVolumeSlider]")]private Slider bgmVolumeSlider;
 [SerializeField,Header("[Video - FullScreenToggle]")]private Toggle fullScreenToggle; 
 [SerializeField,Header("[Video - ResoulationDropdown]")]private Dropdown resoulationDropdown;
 [SerializeField,Header("[Language -languageDropdowb]")]private Dropdown languageDropdown;

 #endregion
#region HUD UI
   [SerializeField,Header("[UserName]")]private Text userNameText;
   [SerializeField,Header("[Inventory]")]private Button inventoryButton;
   [SerializeField,Header("[Shop]")]private Button shopButton;
   [SerializeField,Header("[Setting]")]private Button settingButton;
   [SerializeField,Header("[Quit]")]private Button quitButton;
   [SerializeField,Header("[party]")]private Button partyButton;
   [SerializeField,Header("[GameStart]")]private Button gameStartButton;
#endregion

   private void Awake()
   {
       Init();
   } 
   private void Init()
   {
        quitButton.onClick.AddListener
        (
          delegate
          {           
            SettingDataController.Instance.SaveSettingData();        
            Application.Quit();
              
          }
        );
        settingButton.onClick.AddListener(OnClickSettingButton);
        settingExitButton.onClick.AddListener(OnClickSettingExitButton);
        navigationSoundButton.onClick.AddListener(OnClickNavigationSoundButton);
        navigationVideoButton.onClick.AddListener(OnClickNavigationVideoButton);
        navigationLanguageButton.onClick.AddListener(OnClickNavigationLanguageButton);
        muteYesToggle.onValueChanged.AddListener(delegate{OnClickMuteToggle();});
        bgmVolumeSlider.onValueChanged.AddListener(delegate{OnChangedBGMSlider();});
        fullScreenToggle.onValueChanged.AddListener(delegate{OnClickFullScreenToggle();});
        resoulationDropdown.onValueChanged.AddListener(delegate{OnSelectResoulationDropdown();});
        hudCanvas.gameObject.SetActive(true);
        settingAndExitCanvas.gameObject.SetActive(false);
   }
  
   #region SettingPanel - Sound

   private void OnClickSettingExitButton()
   {
        SoundController.Instance.OnPlayClickSound();
        #if UNITY_EDITOR
        SettingDataController.Instance.SaveSettingData();
        #endif
        settingPopUp.gameObject.SetActive(false);
        settingAndExitCanvas.gameObject.SetActive(false);
           
   }
   private void OnClickMuteToggle()
   {
      if(muteYesToggle.isOn == true)
      {
        SoundController.Instance.AudioSource.mute = true;
        SettingDataController.Instance.SettingData.isAllMute =true;
      }
      else
      { 
        SoundController.Instance.AudioSource.mute =false;
        SettingDataController.Instance.SettingData.isAllMute =false;
      }      
   }
   private void OnChangedBGMSlider()
   {
      SoundController.Instance.AudioSource.volume = bgmVolumeSlider.value;
      SettingDataController.Instance.SettingData.bgmVolume = bgmVolumeSlider.value;
   }
  #endregion
   #region SettingPanel - Video

   private void OnClickFullScreenToggle()
    {
        if(fullScreenToggle.isOn == true)
        {
            ResoulationController.Instance.SetScreenMode(true);
        }
        else
        {
            ResoulationController.Instance.SetScreenMode(false);  
        }    
    } 
    private void OnSelectResoulationDropdown()
    {
         ResoulationController.Instance.SetScreenResoulation(resoulationDropdown.value);
    } 
   #endregion   

#region SettingPanel - language
   private void OnSelectLanguageDropdown()
   {
      if(languageDropdown.value == 0)
      {
                LocalizationTextController.Instance.OnChangeLanguage(0);
      }
      else if(languageDropdown.value == 1)
      {
                LocalizationTextController.Instance.OnChangeLanguage(1);
      }
   }
#endregion

   private void OnClickSettingButton()
   {
       SoundController.Instance.OnPlayClickSound();
       settingAndExitCanvas.gameObject.SetActive(true);
       settingPopUp.gameObject.SetActive(true);
       videoContent.gameObject.SetActive(false);
       languageContent.gameObject.SetActive(false);
       soundContent.gameObject.SetActive(true);    
       if(SettingDataController.Instance.SettingData.isAllMute == true)
        {
            muteYesToggle.isOn =true;        
        }
        else
        {
            muteYesToggle.isOn =false;
        }
       bgmVolumeSlider.value = SettingDataController.Instance.SettingData.bgmVolume;
       if(SettingDataController.Instance.SettingData.isFullScreen == true)
       {
          fullScreenToggle.isOn = true;         
       }
       else
       {
          fullScreenToggle.isOn =false;
       }
      resoulationDropdown.value= SettingDataController.Instance.SettingData.resoulationDropdownIndex; 
      languageDropdown.value = SettingDataController.Instance.SettingData.languageDropdownIndex;
   }
   private void OnClickNavigationSoundButton()
   {
      SoundController.Instance.OnPlayClickSound();
      videoContent.gameObject.SetActive(false);
      languageContent.gameObject.SetActive(false);
      soundContent.gameObject.SetActive(true);      
   }
   private void OnClickNavigationVideoButton()
   {
     SoundController.Instance.OnPlayClickSound();
     soundContent.gameObject.SetActive(false);
     languageContent.gameObject.SetActive(false);
     videoContent.gameObject.SetActive(true);            
   }
   private void OnClickNavigationLanguageButton()
   {
      SoundController.Instance.OnPlayClickSound();
      soundContent.gameObject.SetActive(false);
      videoContent.gameObject.SetActive(false);
      languageContent.gameObject.SetActive(true);
   }
}
}

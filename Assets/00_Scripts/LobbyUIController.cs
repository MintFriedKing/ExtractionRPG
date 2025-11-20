using UnityEngine;
using UnityEngine.UI;
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
 [SerializeField,Header("[SettingExitButton]")]private Button settingExitButton;
 [SerializeField,Header("[BGMVolumeSlider]")]private Slider bgmVolumeSlider;
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
        quitButton.onClick.AddListener(()=>Application.Quit());
        settingButton.onClick.AddListener(OnClickSettingButton);
        settingExitButton.onClick.AddListener(OnClickSettingExitButton);
        bgmVolumeSlider.onValueChanged.AddListener(delegate{OnChangedBGMSlider();});
        hudCanvas.gameObject.SetActive(true);
        settingAndExitCanvas.gameObject.SetActive(false);
        bgmVolumeSlider.value = 1f;
   }

   private void OnClickSettingButton()
   {
       SoundController.Instance.OnPlayClickSound();
       settingAndExitCanvas.gameObject.SetActive(true);
       settingPopUp.gameObject.SetActive(true);
   }
   private void OnClickSettingExitButton()
   {
        SoundController.Instance.OnPlayClickSound(); 
        settingPopUp.gameObject.SetActive(false);
        settingAndExitCanvas.gameObject.SetActive(false);    
   }
   private void OnChangedBGMSlider()
   {
     SoundController.Instance.AudioSource.volume = bgmVolumeSlider.value;
   }

}

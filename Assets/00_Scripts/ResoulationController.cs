using UnityEngine;
using UnityEngine.UI;

namespace ExtractionRPG
{
public class ResoulationController : MonoBehaviour
{
    public static ResoulationController Instance;

        private void Awake()
        {
            Instance =this;
        }
        private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Init();
    }
    private void Init()
    {
        if(SettingDataController.Instance.SettingData.isFullScreen == true)
        {
           SetScreenMode(true);               
        }
        else
        {
            SetScreenMode(false);
        }
        
    }
   public void SetScreenMode(bool _isFullScreen)
   {
            int width = Screen.currentResolution.width;
            int height = Screen.currentResolution.height; 
            FullScreenMode mode;
            if(_isFullScreen == true)
            {
                mode = FullScreenMode.FullScreenWindow; 
                Screen.fullScreenMode = mode;
                SettingDataController.Instance.SettingData.isFullScreen = true; 
            }
            else
            {
               mode = FullScreenMode.Windowed;
               Screen.fullScreenMode = mode;
               SettingDataController.Instance.SettingData.isFullScreen =false; 

            }
            Screen.SetResolution(width,height,mode);
   }
   public void SetScreenResoulation(int _selectNumber)
    {
        FullScreenMode mode;
        if(SettingDataController.Instance.SettingData.isFullScreen ==true)
            {
                 mode =FullScreenMode.FullScreenWindow;              
            }
            else
            {
                 mode = FullScreenMode.Windowed;
            }
        switch(_selectNumber)
        {
            case 0:
            Screen.SetResolution(2560,1440,mode);
            SettingDataController.Instance.SettingData.resoulationDropdownIndex = 0;
            break;
            case 1:
            Screen.SetResolution(1920,1080,mode);
            SettingDataController.Instance.SettingData.resoulationDropdownIndex = 1;
            break;
            case 2:
            Screen.SetResolution(1280,720,mode);
            SettingDataController.Instance.SettingData.resoulationDropdownIndex = 2;
            break;
        }
    }
} 
}
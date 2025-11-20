using UnityEngine;
using System.IO;

namespace ExtractionRPG
{

public class SettingData
{
  public bool isAllMute;    
  public float bgmVolume;
  public float effectVolume;
  public bool isFullScreen;
  public int dropdownIndex; 
}
public class SettingDataController : MonoBehaviour
{
    public static SettingDataController Instance;
    public SettingData SettingData{get{return settingData;}set{settingData = value;}}
    [SerializeField,Header("[SettingDataFileName]")]private string settingFileName;
    private SettingData settingData;
    private string path;
        private void Awake()
        {
            Instance = this;
            Init();
        }
        private void Init()
        {
          DontDestroyOnLoad(this.gameObject);
            path = Path.Combine(Application.persistentDataPath,settingFileName);
          #if UNITY_EDITOR
            path = Path.Combine(Application.dataPath,settingFileName);
          #endif

          if(File.Exists(path) == true)
          {
            Debug.Log("셋팅 값 저장되서 발뺌");
            string jsonData =File.ReadAllText(path);
            SettingData = JsonUtility.FromJson<SettingData>(jsonData);                  
          }
          else
          {     
            settingData = new SettingData()
            {
                  isAllMute = false,
                  bgmVolume = 1f,
                  effectVolume =1f,
                  isFullScreen  = true,
                  dropdownIndex = 1
            };
            string jsonData = JsonUtility.ToJson(settingData);
            File.WriteAllText(path,jsonData);
            {
                Debug.Log("첫 세팅값 저장");        
            }
          }
       }
        public void SaveSettingData()
        {
            string saveJsonData = JsonUtility.ToJson(settingData);
            File.WriteAllText(path,saveJsonData);
        }


    }
}

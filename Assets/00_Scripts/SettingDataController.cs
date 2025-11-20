using UnityEngine;
using System.IO;
namespace ExtractionRPG
{
class SettingData
{
  public bool isAllMute;    
  public float bgmVolume;
  public float effectVolume;
}
public class SettingDataController : MonoBehaviour
{
    [SerializeField,Header("[SettingDataFileName]")]private string settingFileName;
    public static SettingDataController Instance;
    

        private void Awake()
        {
            Instance = this;
        }
        private void Start() 
        {
          string path = Path.Combine(Application.persistentDataPath,settingFileName);
          #if UNITY_EDITOR
            path = Path.Combine(Application.dataPath,settingFileName);
          #endif

          if(File.Exists(path) == true)
          {
            Debug.Log("셋팅 값 저장되서 발뺌");
            return;          
          }
          else
          {     
            SettingData settingData = new SettingData()
            {
                  isAllMute = false,
                  bgmVolume = 1f,
                  effectVolume =1f
            };
            string jsonData = JsonUtility.ToJson(settingData);
            File.WriteAllText(path,jsonData);
            {
                Debug.Log("첫 세팅값 저장");        
            }
          }
       }
    }
}

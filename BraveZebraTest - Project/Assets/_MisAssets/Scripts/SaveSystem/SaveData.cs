using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    #region fields

    private List<ISavable> _dataToSave;

    #endregion

    #region Methods

    private void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    public void Save()
    {
        foreach(ISavable savable in dataToSave)
        {
            savable.SaveData(savable.SaveKey);
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnSceneChanged(Scene current, Scene next)
    {
        Save();
    }

    #endregion

    #region Properties

    public List<ISavable> dataToSave
    {
        get
        {
            if (_dataToSave == null)
            {
                _dataToSave = new List<ISavable>();
            }
            return _dataToSave;
        }
        set => _dataToSave = value;
    }

    #endregion

}

using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private List<ILoadable> _dataToLoad;

    #endregion

    #region Methods

    private void Awake()
    {
        Load();
    }

    public void Load()
    {
        foreach(ILoadable loadable in dataToLoad)
        {
            loadable.LoadData();
        }
    }

    #endregion

    #region Properties

    public List<ILoadable> dataToLoad
    {
        get
        {
            if (_dataToLoad == null)
            {
                _dataToLoad = new List<ILoadable>();
            }
            return _dataToLoad;
        }
        set => _dataToLoad = value;
    }

    #endregion
}

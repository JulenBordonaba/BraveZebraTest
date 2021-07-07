using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HUDHeart : MonoBehaviour
{
    #region fields

    [SerializeField]
    private Sprite _filledSprite;
    [SerializeField]
    private Sprite _emptySprite;
    private Image _image;
    private float _index;

    #endregion

    #region Methods

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetFilled(bool filled)
    {
        _image.sprite = filled ? _filledSprite : _emptySprite;
    }

    #endregion

    #region Properties

    public float index
    {
        get => _index;
        set => _index = value;
    }

    #endregion
}

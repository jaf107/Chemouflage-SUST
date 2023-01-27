using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIplaceholder : MonoBehaviour
{
    [SerializeField]
    private bool _isPlaceholderHideOnSelect;

    [SerializeField]
    private TMP_InputField _inputField;

    public void OnInputFieldSelect()
    {
        if (_isPlaceholderHideOnSelect == true)
        {
            _inputField.placeholder.gameObject.SetActive(false);
        }
    }
    public void OnInputFieldDeselect()
    {
        if (_isPlaceholderHideOnSelect == true)
        {
            _inputField.placeholder.gameObject.SetActive(true);
        }
    }
}

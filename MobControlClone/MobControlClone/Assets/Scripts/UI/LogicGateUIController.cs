using System;
using Controllers;
using Enums;
using UnityEngine;
using TMPro;

namespace UI
{
    public class LogicGateUIController : MonoBehaviour
    {
        [SerializeField] private LogicGateController logicGateController;
        [SerializeField] private TextMeshPro logicGateText;

        private void Awake()
        {
           Init(logicGateController.gateType);
        }

        private void Init(LogicGateType gateType)
        {
            switch (gateType)
            {
                case LogicGateType.Add:
                    logicGateText.text = "+" + logicGateController.gateNumber;
                    break;
                case LogicGateType.Multiply:
                    logicGateText.text = "x" + logicGateController.gateNumber;
                    break;
               
            }
        }
    }
}

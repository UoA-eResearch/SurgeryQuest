using System;
 using UnityEngine;
 using TMPro;
 
 namespace UnityStandardAssets.Utility
 {
     [RequireComponent(typeof (TextMeshPro))]
     public class FPSCounter : MonoBehaviour
     {
         const float fpsMeasurePeriod = 0.5f;
         private int m_FpsAccumulator = 0;
         private float m_FpsNextPeriod = 0;
         private int m_CurrentFps;
         const string display = "{0} FPS";
         private TextMeshPro m_Text;
 
 
         private void Start()
         {
             m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
             m_Text = GetComponent<TextMeshPro>();
         }
 
 
         private void Update()
         {
             // measure average frames per second
             m_FpsAccumulator++;
             if (Time.realtimeSinceStartup > m_FpsNextPeriod)
             {
                 m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                 m_FpsAccumulator = 0;
                 m_FpsNextPeriod += fpsMeasurePeriod;
                 m_Text.text = string.Format(display, m_CurrentFps);
                 if (m_CurrentFps < 30) {
                     m_Text.color = Color.red;
                 } else if (m_CurrentFps < 50) {
                     m_Text.color = Color.yellow;
                 } else {
                     m_Text.color = Color.green;
                 }
             }
         }
     }
 }
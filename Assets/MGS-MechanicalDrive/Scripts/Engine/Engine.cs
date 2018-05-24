﻿/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Engine.cs
 *  Description  :  Define Engine component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/22/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Machinery
{
    [AddComponentMenu("Mogoson/Machinery/Engine")]
    public class Engine : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Revolution velocity (r/min).
        /// </summary>
        public float RPM = 60;

        /// <summary>
        /// Current revolution velocity.
        /// </summary>
        protected float rpm = 0;

        protected float threshold = 1;

        /// <summary>
        /// Damper of engine rpm.
        /// </summary>
        public float damper = 0.5f;

        /// <summary>
        /// Gear drive by this engine.
        /// </summary>
        public Gear gear;
        #endregion

        #region Protected Method
        protected virtual void Update()
        {
            if (Mathf.Abs(rpm - RPM) <= threshold)
                rpm = RPM;
            else
                rpm = Mathf.Lerp(rpm, RPM, damper * Time.deltaTime);

            if (rpm == 0)
                enabled = false;
            else
                gear.AngularDrive(rpm * 6);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Turn on engine.
        /// </summary>
        public virtual void TurnOn()
        {
            enabled = true;
        }

        /// <summary>
        /// Turn off engine.
        /// </summary>
        public virtual void TurnOff()
        {
            RPM = 0;
        }
        #endregion
    }
}
﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Examples.Grabbables
{
    /// <summary>
    /// This type of grab makes the grabbed object track the position of the grabber
    /// The follow can be tight or loose depending on the lagAmount specified.
    /// </summary>

    public class GragControl : BaseGrabbable
    {
        //[Range(1, 10)]
        //public float lagAmount = 5;
        public float rotationSpeed = 5;
        private Rigidbody rb;

        protected override void Start()
        {
            base.Start();
            rb = GetComponent<Rigidbody>();
        }

        protected override void AttachToGrabber(BaseGrabber grabber)
        {
            base.AttachToGrabber(grabber);
            rb.useGravity = false;
        }

        protected override void DetachFromGrabber(BaseGrabber grabber)
        {
            base.DetachFromGrabber(grabber);
            rb.useGravity = true;
        }

        protected override void OnGrabStay()
        {
            base.OnGrabStay();
            transform.position = GrabberPrimary.GrabHandle.position;
        }
    }
}

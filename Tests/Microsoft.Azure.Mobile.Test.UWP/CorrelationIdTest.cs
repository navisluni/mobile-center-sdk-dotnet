﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Mobile.Crashes;

namespace Microsoft.Azure.Mobile.Test.UWP
{
    [TestClass]
    public class CorrelationIdTest
    {
        /// <summary>
        /// Verify that crashes sets the correlation id on start.
        /// </summary>
        [TestMethod]
        public void CrashesSetsCorrelationId()
        {
            MobileCenter.Start("secret", typeof(Crashes.Crashes));
#pragma warning disable CS0612 // Type or member is obsolete
            Assert.IsNotNull(MobileCenter.Instance.InstanceCorrelationId);
#pragma warning restore CS0612 // Type or member is obsolete
        }

        /// <summary>
        /// Verify that Crashes doesn't replace an existing correlation id
        /// </summary>
        // Verify that crashes replaces a null correlation id.
        [TestMethod]
        public void CrashesLeavesExistingCorrelationId()
        {
            var originalCorrelationId = Guid.NewGuid();
#pragma warning disable CS0612 // Type or member is obsolete
            MobileCenter.Instance.InstanceCorrelationId = originalCorrelationId;
            MobileCenter.Start("secret", typeof(Crashes.Crashes));
            Assert.AreEqual(originalCorrelationId, MobileCenter.Instance.InstanceCorrelationId);
#pragma warning restore CS0612 // Type or member is obsolete
        }
    }
}

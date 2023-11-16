using GDriveBackup.BusinessLayer.Domain.CommandLineAdapter;
using NUnit.Framework;
using Shouldly;
using System;
using GDriveBackup.BusinessLayer.Domain.Backup;
using GDriveBackup.Core.Extensions;
// ReSharper disable InconsistentNaming

namespace GDriveBackup.Tests.UnitTests.BusinessLayer
{
    [TestFixture]
    internal class WithBackupDomain
    {
        [Test]
        public void Do_Backup()
        {
            var backup = new BackupDomain_v2(DateTime.MinValue);
            backup.Start(  );
        }
    }
}
using System;
using System.IO;
using GDriveBackup.ServiceLayer.GoogleDrive.Authenticate;
using GDriveBackup.ServiceLayer.GoogleDrive.FolderWalker;
using GDriveBackup.ServiceLayer.GoogleDrive.Service;
using Google.Apis.Drive.v3;
using NUnit.Framework;

namespace GDriveBackup.Tests.UnitTests.ServiceLayer
{
    [TestFixture]
    internal class WithGoogleDriveFolderWalker
    {
        private void DoFolderHandler( DriveService service, WalkerCurrentFolder currentFolder)
        {
            Console.WriteLine( $"DoFolderHandler( currentFolder [{currentFolder.LocalFullPath}] )" );

            try
            {
                // This will create the directory if it does not exist yet.
                Directory.CreateDirectory(currentFolder.LocalFullPath);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public WithGoogleDriveFolderWalker()
        {
        }

        [Test]
        public void DoWalkFolders()
        {
            var gAuth = new GoogleDriveAuthenticate();
            var credential = gAuth.Authenticate();

            var gService = new GoogleDriveService();
            var service = gService.GetService(credential);

            var walker = new GoogleDriveFolderWalker( service )
            {
                OnFolder = DoFolderHandler
            };

            walker.Walk();
        }
    }
}

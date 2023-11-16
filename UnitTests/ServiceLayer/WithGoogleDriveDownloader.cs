using GDriveBackup.ServiceLayer.GoogleDrive.Authenticate;
using GDriveBackup.ServiceLayer.GoogleDrive.Downloader;
using GDriveBackup.ServiceLayer.GoogleDrive.Files;
using GDriveBackup.ServiceLayer.GoogleDrive.Service;
using Google.Apis.Drive.v3;
using NUnit.Framework;


// ReSharper disable IdentifierTypo

namespace GDriveBackup.Tests.UnitTests.ServiceLayer
{
    [TestFixture]
    internal class WithGoogleDriveDownloader
    {
        private const string LocalPath = @"C:\Temp";

        private DriveService _service;

        private void DoFailedHandler(string localPath, string localExt, string localMimeType, Google.Apis.Drive.v3.Data.File file)
        {

        }

        private void DoDownload( string localPath, string gDriveFileId )
        {
            var gDriveFile = new GoogleDriveFile( this._service );
            var file = gDriveFile.GetFile( gDriveFileId );

            var downloader = GoogleDriveDownloaderFactory
                .GetInstance()
                .GetDownloader( this._service, file );

            downloader.OnFailed = DoFailedHandler;
            downloader.DownloadFile( localPath, file );
        }

        public WithGoogleDriveDownloader()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var gAuth = new GoogleDriveAuthenticate();
            var credential = gAuth.Authenticate();

            var gService = new GoogleDriveService();
            this._service = gService.GetService( credential );
        }

        [OneTimeTearDown]
        public void OneTimeTeardDown()
        {

        }

        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void DoDownloadFile_Txt_Fail()
        {
            // Folder: RopeMarks;
            // File: Name [Info.txt], MimeType [text/plain], Id [1vV6AnifFeDjfXTp_A9DRfp72u1T4z7ih]
            var gDriveFileId = "1vV6AnifFeDjfXTp_A9DRfp72u1T4z7ih";

            this.DoDownload( "-some-invalid-local-path-", gDriveFileId);
        }

        [Test]
        public void DoDownloadFile_Txt_ok()
        {
            // Folder: RopeMarks;
            // File: Name [Info.txt], MimeType [text/plain], Id [1vV6AnifFeDjfXTp_A9DRfp72u1T4z7ih]
            var gDriveFileId = "1vV6AnifFeDjfXTp_A9DRfp72u1T4z7ih";

            this.DoDownload( LocalPath, gDriveFileId );
        }

        // Folder: RopeMarks;
        // File: Name[RoadMap], MimeType[application/vnd.google-apps.document], Id[]
        [TestCase( "1wGcjcdY3KJSIcLFTI_bmifFlIG0qZ-ASGgwNLsvDGZ4" )]
        // File: Name [Ongoing activity (RopeMarks)], MimeType [application/vnd.google-apps.document], Id [].
        [TestCase( "1gaI5su2d-mmNh1jFheg9vYB432fadn5YDhErBH8qaI0" )]
        public void DownloadFile_Gdoc_ok( string gDriveFileId )
        {
            this.DoDownload( LocalPath, gDriveFileId );
        }
    }
}

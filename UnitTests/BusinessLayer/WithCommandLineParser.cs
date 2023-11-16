using GDriveBackup.BusinessLayer.Domain.CommandLineAdapter;
using NUnit.Framework;
using Shouldly;
using System;
using GDriveBackup.Core.Extensions;
// ReSharper disable InconsistentNaming

namespace GDriveBackup.Tests.UnitTests.BusinessLayer
{
    [TestFixture]
    internal class WithCommandLineParser
    {
        #region Command "Backup"

        [TestCase("-b")]
        [TestCase("--backup")]
        public void DoParseBackup01a(string command)
        {
            var args = new string[]
            {
                command
            };
            var model = CommandLineParser.Parse(args);

            model.Error.ShouldBe(false);
            model.BackupChanges.ShouldBe(false);
            model.BackupAll.ShouldBe(false);
        }

        [TestCase( "-b")]
        [TestCase("--backup")]
        public void DoParseBackup01b( string commandLine )
        {
            var model = CommandLineParser.Parse( commandLine.ToCommandLineArgs() );
            model.Error.ShouldBe( false );
            model.BackupChanges.ShouldBe(false);
            model.BackupAll.ShouldBe(false);
        }


        [TestCase( "-b all" )]
        [TestCase( "--backup all" )]
        public void DoParseBackup02( string commandLine )
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());

            model.Error.ShouldBe( false );
            model.BackupAll.ShouldBe( true );
        }

        [TestCase("-b changes")]
        [TestCase("--backup changes")]
        public void DoParseBackup03( string commandLine)
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());

            model.Error.ShouldBe( false );
            model.BackupChanges.ShouldBe( true );
        }

        [TestCase("-b changes all")]
        [TestCase("--backup changes all")]
        public void DoParseBackup04a(string commandLine)
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());

            model.Error.ShouldBe(false);
            model.BackupChanges.ShouldBe(true);
            model.BackupAll.ShouldBe(false);
        }
        [TestCase("-b  all changes")]
        [TestCase("--backup all changes ")]
        public void DoParseBackup04b(string commandLine)
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());

            model.Error.ShouldBe(false);
            model.BackupChanges.ShouldBe(false);
            model.BackupAll.ShouldBe(true);
        }

        #endregion


        #region Command "Config"


        [TestCase("-c")]
        [TestCase("--config")]
        public void DoParseConfig01(string commandLine)
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());
            model.Error.ShouldBe(false);
            model.ConfigReset.ShouldBe(false);
            model.ConfigResetLastRunDate.ShouldBe(false);
        }


        [TestCase("-c reset")]
        [TestCase("--config reset")]
        public void DoParseConfig02(string commandLine)
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());

            model.Error.ShouldBe(false);
            model.ConfigReset.ShouldBe(true);
        }

        [TestCase("-c resetLastRunDate")]
        [TestCase("--config resetLastRunDate")]
        public void DoParseConfig03(string commandLine)
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());

            model.Error.ShouldBe(false);
            model.ConfigResetLastRunDate.ShouldBe(true);
        }

        [TestCase("-c reset     resetLastRunDate")]
        [TestCase("--config reset resetLastRunDate")]
        public void DoParseConfig04a(string commandLine)
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());

            model.Error.ShouldBe(false);
            model.ConfigReset.ShouldBe(true);
            model.ConfigResetLastRunDate.ShouldBe(false);
        }
        [TestCase("-c resetLastRunDate reset     ")]
        [TestCase("--config resetLastRunDate  reset ")]
        public void DoParseConfig04b(string commandLine)
        {
            var model = CommandLineParser.Parse(commandLine.ToCommandLineArgs());

            model.Error.ShouldBe(false);
            model.ConfigReset.ShouldBe(false);
            model.ConfigResetLastRunDate.ShouldBe(true);
        }

        #endregion

    }
}
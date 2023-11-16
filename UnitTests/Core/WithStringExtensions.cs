using GDriveBackup.Core.Extensions;
using NUnit.Framework;
using Shouldly;

namespace GDriveBackup.Tests.UnitTests.Core
{
    [TestFixture]
    internal class WithStringExtensions
    {
        [TestCase( "-a a -b b -c c", 6 )]
        [TestCase("-a      a       -b      b       -c     c", 6)]
        [TestCase("-a -b", 2)]
        public void DoToCommandLineArguments( string commandLine, int expectedArgumentCount )
        {
            var args = commandLine.ToCommandLineArgs();

            args.Length.ShouldBe( expectedArgumentCount );
        }
    }
}

using System;
using System.Diagnostics;
using Logic.Core;
using Moq;
using NUnit.Framework;

namespace Test.Logic.Core
{
    [TestFixture]
    public class ExerciseTest
    {
        [Test]
        public void Test()
        {
            //  Arrange
            const string url = "MaxPower";
            var mockedHttpWebRequestWrapper = new MockHttpWebRequestWrapper(new DateTime(2001, 9, 11));
            var subject = new UrlSubject("MaxPower", mockedHttpWebRequestWrapper);
            
            var observer = new UrlObserver("MaxPowerObserver", url);
            subject.Attach(observer);

            //  Act and assert(USING THE POWERS OF YOUR EYEBALLS!!!!)

            //  Assert #1
            //  Message should be printed right now as the program has entered it's state machine.
            Console.WriteLine("Assert #1\nA message should appear below!\n---------");
            subject.CheckDate();
            Console.WriteLine("---------");

            //  Assert #2
            //  No message should appear now as we don't make any changes to mockedHttpWebRequestWrapper's LastModified property.
            Console.WriteLine("Assert #2\nNo message should appear below!\n---------");
            subject.CheckDate();
            Console.WriteLine("---------");

            //  Act
            //  change the mockedHttpWebRequestWrapper's LastModified Property.
            mockedHttpWebRequestWrapper.LastModified = new DateTime(2015, 12, 12);

            //  Assert #3
            //  A message should appear.
            Console.WriteLine("Assert #3\nA message should appear below!\n---------");
            subject.CheckDate();
            Console.WriteLine("---------");
        }
    }

    class MockHttpWebRequestWrapper : IWebRequestWrapper
    {
        public MockHttpWebRequestWrapper(DateTime lastModified)
        {
            LastModified = lastModified;
        }

        public void ChangedDate(DateTime dateTime)
        {
            LastModified = dateTime;
        }

        public DateTime LastModified { get; set; }
    }
}

using System;

namespace Logic.Core
{
    public class UrlObserver : IUrlObserver
    {
        public UrlObserver(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public string Name { get; private set; }
        public string Url { get; private set; }

        public UrlSubject UrlSubject { get; set; }

        public void Notify(UrlSubject subject)
        {
            Console.WriteLine("Observer '{0}'\n\tnoticed a date change on '{1}'.\n\tNew date is: {2}", Name, Url, subject.LastModified);
        }
    }
}

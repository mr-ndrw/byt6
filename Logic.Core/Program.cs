using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace Logic.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            //  restore memento

            UrlSubjectMemento googleMemento, mtrzaskaMemento, onetplMemento;

            var jsonSerializer = new DataContractJsonSerializer(typeof(UrlSubjectMemento));

            var stream = new FileStream("google-meneto.json", FileMode.Open);
            googleMemento = (UrlSubjectMemento) jsonSerializer.ReadObject(stream);
            stream.Close();

            stream = new FileStream("mtrzaska-meneto.json", FileMode.Open);
            mtrzaskaMemento = (UrlSubjectMemento)jsonSerializer.ReadObject(stream);
            stream.Close();

            stream = new FileStream("onetpl-meneto.json", FileMode.Open);
            onetplMemento = (UrlSubjectMemento)jsonSerializer.ReadObject(stream);
            stream.Close();

            var googleSubject = new UrlSubject(googleMemento);
            var mtrzaskaSubject = new UrlSubject(mtrzaskaMemento);
            var onetplSubject = new UrlSubject(onetplMemento);

            googleSubject.Attach(new UrlObserver("GoogleObserver1", googleSubject.Url));
            mtrzaskaSubject.Attach(new UrlObserver("MtrzaskaObserver1", mtrzaskaSubject.Url));
            onetplSubject.Attach(new UrlObserver("OnetObserver1", onetplSubject.Url));

            var subjectList = new List<UrlSubject>(){googleSubject, mtrzaskaSubject, onetplSubject};

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----- Iteration #{0} -----", i);
                Console.ForegroundColor = ConsoleColor.White;
                subjectList.ForEach(subject => subject.CheckDate());
                Console.ReadKey();
            }

            googleMemento = googleSubject.CreateUrlSubjectMemento();
            mtrzaskaMemento = mtrzaskaSubject.CreateUrlSubjectMemento();
            onetplMemento  = onetplSubject.CreateUrlSubjectMemento();

            stream = new FileStream("google-meneto.json", FileMode.Create);
            jsonSerializer.WriteObject(stream, googleMemento);
            stream.Close();

            stream = new FileStream("mtrzaska-meneto.json", FileMode.Create);
            jsonSerializer.WriteObject(stream, mtrzaskaMemento);
            stream.Close();

            stream = new FileStream("onetpl-meneto.json", FileMode.Create);
            jsonSerializer.WriteObject(stream, onetplMemento);
            stream.Close();

            Console.WriteLine("Done writing");
        }
    }
}

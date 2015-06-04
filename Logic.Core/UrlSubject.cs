using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace Logic.Core
{
    public class UrlSubject : ISubject
    {
        private UrlSubjectState _state;
        private HashSet<IUrlObserver> _observers = new HashSet<IUrlObserver>();
        private IWebRequestWrapper _webConnection;

        public UrlSubject(string url)
        {
            _state = new UrlSubjectState {Url = url};
            _webConnection = new WebRequestWrapper(Url);
        }

        public UrlSubject(string url, IWebRequestWrapper webConnection)
        {
            _state = new UrlSubjectState { Url = url };
            _webConnection = webConnection;
        }

        public UrlSubject(UrlSubjectMemento memento)
        {
            _state = memento.GetState();
            _webConnection = new WebRequestWrapper(Url);
        }


        public string Url
        {
            get { return _state.Url; }
        }

        public DateTime LastModified
        {
            get { return _state.LastModified; }
            set
            {
                if (LastModified == value) return;
                _state.LastModified = value;
                Update();
            }
        }

        public IWebRequestWrapper WebConnection
        {
            get
            {
                return _webConnection;
            }
            set { _webConnection = value; }
        }

        public UrlSubjectMemento CreateUrlSubjectMemento()
        {
            return (new UrlSubjectMemento(_state));
        }

        public void RestoreSubject(UrlSubjectMemento memento)
        {
            _state = memento.GetState();
        }

        public void CheckDate()
        {

            LastModified = _webConnection.LastModified;
        }

        public void Attach(IUrlObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IUrlObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void Update()
        {
            foreach (var observer in _observers) { observer.Notify(this); }
        }
    }
}

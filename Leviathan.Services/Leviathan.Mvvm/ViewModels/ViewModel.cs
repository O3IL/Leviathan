﻿using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.System;
using Windows.UI.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Helpers;
using Leviathan.Mvvm.Properties;

namespace Leviathan.Mvvm.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _frozen;
        private bool _blockUpdates;
        
        private ILogger Logger { get; }

        public ViewModel(ILogger logger)
        {
            Logger = logger;
        }

        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (_blockUpdates) return;

            if (!_frozen)
            {
                void DispatchedHandler()
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }

                try
                {
                    Dispatch(DispatchedHandler);
                }
                catch(Exception ex)
                {
                    Logger.LogError(new EventId(), ex, "Error dispatching Property Changed Event.");
                }
            }
            else
            {
                _updatesQueue.Enqueue(propertyName);
            }
        }        

        protected virtual bool Set<TValue>(ref TValue original, TValue value, [CallerMemberName] string propertyName = null)
        {
            if (original?.Equals(value) ?? false) return false;

            original = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        private readonly ConcurrentQueue<string> _updatesQueue = new ConcurrentQueue<string>();

        public void HoldUpdates() 
        {
            _frozen = true;
        }

        public void ReleaseUpdates() 
        {
            _frozen = false;
            _blockUpdates = false;

            while(_updatesQueue.TryDequeue(out var propertyName))
            {
                OnPropertyChanged(propertyName);
            }
        }

        public static void Dispatch(DispatcherQueueHandler handler)
        {
            CoreApplication.MainView.DispatcherQueue.TryEnqueue(handler);
        }

        public static Task<TResult> Dispatch<TResult>(Func<TResult> handler)
        {
            return CoreApplication.MainView.Dispatcher.AwaitableRunAsync<TResult>(handler);
        }

        public void BlockUpdates()
        {
            _blockUpdates = true;
        }

    }
}

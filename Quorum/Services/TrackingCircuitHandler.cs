using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.Circuits;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;

namespace Quorum.Services
{
    public class TrackingCircuitHandler : CircuitHandler
    {
        public int GetConnectedCircuitsCount()
        {
            return 1;
        }

        public event EventHandler CircuitsChanged;

        protected virtual void OnCircuitsChanged()
        {
            CircuitsChanged?.Invoke(this, EventArgs.Empty);
        }

        public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            try
            {

                OnCircuitsChanged();
                return base.OnConnectionUpAsync(circuit, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Task.FromException(e);
            }
        }

        public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            try
            { 

                OnCircuitsChanged();
                return base.OnConnectionDownAsync(circuit, cancellationToken);
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
                return Task.FromException(e);
            }
        }
    }
}
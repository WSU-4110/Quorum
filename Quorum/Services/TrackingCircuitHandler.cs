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
using Quorum.Data.Hubs;

namespace Quorum.Services
{
    public class TrackingCircuitHandler : CircuitHandler
    {
        HashSet<Circuit> circuits = new HashSet<Circuit>();
        
        public int GetConnectedCircuitsCount()
        {
            return circuits.Count();
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
                circuits.Add(circuit);
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
                circuits.Remove(circuit);
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
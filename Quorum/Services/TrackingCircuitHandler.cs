using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.Circuits;


namespace Quorum.Services
{
    public class TrackingCircuitHandler : CircuitHandler
    {
        private HashSet<Circuit> circuits = new HashSet<Circuit>();

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
                return Task.CompletedTask;
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
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Task.FromException(e);
            }
        }

        public int ConnectedCircuits => circuits.Count;
    }
}
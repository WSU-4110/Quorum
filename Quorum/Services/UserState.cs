using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Services
{
    public class UserState
    {
        public event EventHandler OnChange;

        public void NotifyAvatarUpdate()
        {
            NotifyStateChanged();
        }

        protected void NotifyStateChanged() => OnChange?.Invoke(this, EventArgs.Empty);
    }
}

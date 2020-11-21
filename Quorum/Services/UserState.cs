using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Quorum.Services
{
    public class UserState
    {
        private readonly IJSRuntime _jsRuntime;

        private TimeSpan? _userOffset;

        public UserState(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public event EventHandler OnChange;

        public void NotifyAvatarUpdate()
        {
            NotifyStateChanged();
        }

        public async ValueTask<DateTimeOffset> GetLocalDateTime(DateTimeOffset dateTime)
        {
            if (_userOffset == null)
            {
                int offsetInMinutes = await _jsRuntime.InvokeAsync<int>("getTimeZoneOffset");
                _userOffset = TimeSpan.FromMinutes(-offsetInMinutes);
            }

            return dateTime.ToOffset(_userOffset.Value);
        }

        protected void NotifyStateChanged() => OnChange?.Invoke(this, EventArgs.Empty);
    }
}

using EasyApiWebsite.Contract.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics;
using System.Security.Claims;

namespace EasyApiWebsite.Server.Auth;

internal sealed class PersistingAuthenticationStateProvider : ServerAuthenticationStateProvider, IDisposable
{
    private readonly PersistentComponentState _state;
    private readonly PersistingComponentStateSubscription _subscription;

    private Task<AuthenticationState>? authenticationStateTask;

    public PersistingAuthenticationStateProvider(PersistentComponentState persistentComponentState)
    {
        AuthenticationStateChanged += OnAuthenticationStateChanged;
        _state = persistentComponentState;
        _subscription = _state.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveWebAssembly);
    }

    private void OnAuthenticationStateChanged(Task<AuthenticationState> task)
    {
        authenticationStateTask = task;
    }

    private async Task OnPersistingAsync()
    {
        if (authenticationStateTask is null)
        {
            throw new UnreachableException($"Authentication state not set in {nameof(OnPersistingAsync)}().");
        }

        var authenticationState = await authenticationStateTask;
        var principal = authenticationState.User;

        if (principal.Identity?.IsAuthenticated == true)
        {
            var username = principal.FindFirst(ClaimTypes.Name)?.Value;
            if (username != null)
            {
                _state.PersistAsJson(nameof(User), new User(username));
            }
        }
    }

    public void Dispose()
    {
        _subscription.Dispose();
        AuthenticationStateChanged -= OnAuthenticationStateChanged;
    }
}

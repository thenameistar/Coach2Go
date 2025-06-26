using Blazored.LocalStorage;
using System.Net.Http.Headers;
using Coach2Go.Shared.Dtos;
using Microsoft.AspNetCore.Components;

public class AuthService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;
    private readonly NavigationManager _navigation;

    public UserDto? CurrentUser { get; private set; }  

    public AuthService(ILocalStorageService localStorage, HttpClient http, NavigationManager navigation)
    {
        _localStorage = localStorage;
        _http = http;
        _navigation = navigation;
    }

    public async Task<bool> IsAuthenticated()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        return !string.IsNullOrWhiteSpace(token);
    }

    public async Task SetAuthToken(string token, UserDto user)
    {
        await _localStorage.SetItemAsync("authToken", token);
        await _localStorage.SetItemAsync("currentUser", user);

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        CurrentUser = user;
    }

    public async Task RemoveAuthToken()
    {
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("currentUser");
        _http.DefaultRequestHeaders.Authorization = null;
        CurrentUser = null;
    }

    public async Task CheckAuthentication()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        var user = await _localStorage.GetItemAsync<UserDto>("currentUser");

        if (string.IsNullOrWhiteSpace(token) || user is null)
        {
            _navigation.NavigateTo("/login");
        }
        else
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            CurrentUser = user;
        }
    }
}
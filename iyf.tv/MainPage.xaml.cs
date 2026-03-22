namespace iyf.tv;

public partial class MainPage : ContentPage
{ 
    public MainPage()
    {
        InitializeComponent();
#if ANDROID
        webView.HandlerChanged += (s, e) =>
        {
            if (webView.Handler?.PlatformView is Android.Webkit.WebView nativeWebView)
            {
                nativeWebView.Settings.UserAgentString = "Mozilla/5.0 (Linux; Android TV 10) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Safari/537.36";
            }
        };
#endif
        //webView.Source = null;
        _ = NavigateAfterDelayAsync();
    }

    private async Task NavigateAfterDelayAsync()
    {
        await Task.Delay(10000);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            webView.Source = "https://tv.yfsp.tv";
        });
    }
}

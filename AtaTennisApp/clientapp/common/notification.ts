const enum Theme {
    secondary = "secondary",
    success = "success",
    danger = "danger",
    warning = "warning",
    info = "info",
    light = "light",
    dark = "dark",
}

interface NotificationArgs {
    message: string,
    theme: Theme
}

export 
    class NotificationUtils {


    public static Show(args: NotificationArgs): string {
        return '<d-alert theme=' + args.theme.toString() + ' dismissible show>' + args.message + '</d-alert>'
    }

    public static ShowErrorMessage(message: string): string {
        var args: NotificationArgs = {
            message: message,
            theme: Theme.danger
        }
        return this.Show(args);
    }
}

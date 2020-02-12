import Vue from "vue";
import { i18n } from "../plugins/i18n";

// const enum Theme {
//    secondary = "secondary",
//    success = "success",
//    danger = "danger",
//    warning = "warning",
//    info = "info",
//    light = "light",
//    dark = "dark",
// }

interface MessageArgs {
	message: string,
	title: string
}

interface NotificationArgs {
	message: string;
	title: string;
	group?: string;
	type?: string;
	speed?: number;
	duration?: number;
}

export class NotificationUtils {
  private static ShowNotification(args: NotificationArgs): void {
    Vue.notify({
      group: args.group,
      title: args.title,
      type: args.type,
      text: args.message,
      speed: 500,
      duration: 5000
    });
  }

  public static ShowSuccess(args: MessageArgs): void {
    this.ShowNotification({
      type: "success",
      title: args.title,
      message: args.message
    });
  }

  public static ShowErrorMessage(message: string): void {
    this.ShowNotification({
      type: "error",
      title: i18n.t("error").toString(),
      message: message
    });
  }
}

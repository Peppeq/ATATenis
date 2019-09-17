import Vue from "vue";
import { i18n } from "../plugins/i18n";

//const enum Theme {
//    secondary = "secondary",
//    success = "success",
//    danger = "danger",
//    warning = "warning",
//    info = "info",
//    light = "light",
//    dark = "dark",
//}

interface NotificationArgs {
	message: string;
	title: string;
}

export class NotificationUtils {
	public static Show(args: NotificationArgs): void {
		// return '<d-alert theme=' + args.theme.toString() + ' dismissible show>' + args.message + '</d-alert>'
		Vue.notify({
			group: "foo",
			title: "Important message",
			text: args.message
		});
	}

	public static ShowErrorMessage(message: string): void {
		Vue.notify({
			group: "error",
			title: i18n.t("error").toString(),
			type: "error",
			text: message,
			speed: 500,
			duration: 5000
		});
	}
}

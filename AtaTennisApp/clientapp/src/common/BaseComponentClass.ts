import Vue from "vue";
import { NotificationUtils } from "./notification";
import { i18n } from "@/plugins/i18n";
import { ErrorResponse } from "@/scripts/ajax";
import { logout } from "@/views/user/helper/user-service";

interface TryGetApiArgs<TResult, TArgs> {
	apiMethod: (args: TArgs) => Promise<TResult>;
	showError: boolean;
	requestArgs: TArgs;
}

export abstract class BaseComponentClass extends Vue {
	public async tryGetDataByArgs<TResult, TArgs>(args: TryGetApiArgs<TResult, TArgs>): Promise<TResult> {
		let response: TResult = null;
		try {
			response = await args.apiMethod(args.requestArgs);
		} catch (e) {
			if (args.showError) {
				if (!(e instanceof Error)) {
					e.json().then((errorResponse: ErrorResponse): void => {
						if (errorResponse.StatusCode === "401") {
							// auto logout if 401 response returned from api
							logout();
							location.reload(true);
						}
						if (errorResponse.hasOwnProperty("StatusDescription")) {
							// var error = errorResponse as ErrorResponse;
							this.showError(errorResponse.StatusDescription + " " + errorResponse.Message);
						} else {
							this.showError(i18n.t("errorMessageGeneral").toString());
						}
					});
				} else {
					this.showError(i18n.t("errorMessageGeneral").toString());
				}
			}
			console.log("catch in BaseComponentClass");
			console.log(e);
		}
		return response;
	}

	public showError(message: string): void {
		NotificationUtils.ShowErrorMessage(message);
	}
}

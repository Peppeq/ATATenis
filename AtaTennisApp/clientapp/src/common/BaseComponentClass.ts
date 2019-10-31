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
		console.log(args);
		try {
			response = await args.apiMethod(args.requestArgs);
		} catch (e) {
			let error: ErrorResponse = e;
			if (args.showError) {
				if (error.StatusCode == "401") {
					// auto logout if 401 response returned from api
					logout();
					location.reload(true);
				}
				if (error.StatusCode == "500") {
					this.showError(i18n.t("errorMessageGeneral").toString());
				} else if (e.status == "400") {
					this.showError(e.title);
				} else {
					this.showError(error.StatusDescription + " " + error.Message);
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
